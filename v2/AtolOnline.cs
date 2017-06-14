using Newtonsoft.Json;
using RestSharp;
using System;

namespace AtolOnline.v2
{
    public class Balancer
    {
        private string _ip { get; set; }
        private short _port { get; set; }
        private string _groupCode { get; set; }
        private const string _version = "v2";

        private RestClient client;

        public Balancer(string ip, short port, string groupCode)
        {
            _ip = ip;
            _port = port;
            _groupCode = groupCode;
            client = new RestClient(string.Format("http://{0}:{1}/{2}/{3}", _ip, _port, _version, groupCode));
        }

        public DocumentResponse Sell(Document document)
        {
            RestRequest request = new RestRequest("sell", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
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
                throw new AtolOnlineException("Document:" + JsonConvert.SerializeObject(document) + ", Url:" + client .BaseUrl + ", Response code:" + response.StatusCode + ", Response text:" + response.Content);

        }

        public DocumentResponse SellRefund(Document document)
        {
            RestRequest request = new RestRequest("sell_refund", Method.POST);
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
            RestRequest request = new RestRequest("buy", Method.POST);
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
            RestRequest request = new RestRequest("buy_refund", Method.POST);
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
            RestRequest request = new RestRequest("report/" + uuid, Method.GET);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<CheckResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);
        }
    }
}