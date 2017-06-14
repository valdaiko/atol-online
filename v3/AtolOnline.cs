using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;

// documentation on Telegram https://t.me/atolonline
namespace AtolOnline.v3
{
    public class Balancer
    {
        private string _url { get; set; }
        private string _groupCode { get; set; }

        private string _login { get; set; }
        private string _password { get; set; }

        private const string _version = "v3";

        private string _logPath { get; set; }

        private RestClient client;

        public Balancer(string url, string groupCode, string login, string password, string logPath)
        {
            _url = url;
            _groupCode = groupCode;
            _login = login;
            _password = password;
            _logPath = logPath;
            client = new RestClient(string.Format("{0}/{1}/", _url, _version));
        }

        private string GetToken()
        {
            RestRequest request = new RestRequest("getToken", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { Login = _login, Pass = _password }), ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                try
                {
                    var tokenDoc = JsonConvert.DeserializeObject<TokenDocument>(response.Content);
                    if (tokenDoc == null)
                    {
                        throw new AtolOnlineException("Null token document. " + "login:" + _login + " , pass:" + _password + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);
                    }
                    if (string.IsNullOrWhiteSpace(tokenDoc.Token))
                    {
                        throw new AtolOnlineException("Empty token. Text:" + tokenDoc.Text + ", login:" + _login + " , pass:" + _password + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);
                    }
                    else
                        return tokenDoc.Token;
                }
                catch (Exception ex)
                {
                    throw new AtolOnlineException("Exception" + ex.Message + "login:" + _login + " , pass:" + _password + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);
                }
            }
            else
                throw new AtolOnlineException("login: " + _login + ", pass: " + _password + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);
        }

        public DocumentResponse Sell(Document document)
        {
            RestRequest request = new RestRequest(string.Format("{0}/sell?tokenid={1}", _groupCode, GetToken()), Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            Log(JsonConvert.SerializeObject(document));

            var response = client.Execute(request);

            Log(JsonConvert.SerializeObject(response.Content));

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                try
                {
                    return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    throw new AtolOnlineException("Exception" + ex.Message + "Document:" + JsonConvert.SerializeObject(document) + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);
                }
            }
            else
                throw new AtolOnlineException("Document:" + JsonConvert.SerializeObject(document) + ", Url:" + client.BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);

        }

        public DocumentResponse SellRefund(Document document)
        {
            RestRequest request = new RestRequest(string.Format("{0}/sell_refund?tokenid={1}", _groupCode, GetToken()), Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);

        }


        public DocumentResponse Buy(Document document)
        {
            RestRequest request = new RestRequest(string.Format("{0}/buy?tokenid={1}", _groupCode, GetToken()), Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);
        }

        public DocumentResponse BuyRefund(Document document)
        {
            RestRequest request = new RestRequest(string.Format("{0}/buy_refund?tokenid={1}", _groupCode, GetToken()), Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);
        }


        public CheckResponse Report(string uuid)
        {
            RestRequest request = new RestRequest(string.Format("{0}/report?tokenid={1}", _groupCode, GetToken()), Method.GET);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<CheckResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);
        }

        private void Log(string data)
        {
            using (TextWriter tw = new StreamWriter(_logPath, true))
            {
                tw.WriteLine(DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + " - " + data);
            }
        }
    }
}