using Newtonsoft.Json;
using RestSharp;


namespace AtolOnline.v1
{
    public class Balancer
    {
        private string _ip { get; set; }
        private short _port { get; set; }
        private long _inn { get; set; }
        private const string _version = "v1";

        private RestClient client;

        public Balancer(string ip, short port, long inn)
        {
            _ip = ip;
            _port = port;
            _inn = inn;
            client = new RestClient(string.Format("http://{0}:{1}/{2}/{3}", _ip, _port, _version, _inn));
        }

        public DocumentResponse Sale(Document document)
        {
            RestRequest request = new RestRequest("sale", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);

        }

        public DocumentResponse Return(Document document)
        {
            RestRequest request = new RestRequest("return", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(document), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return JsonConvert.DeserializeObject<DocumentResponse>(response.Content);
            }
            else
                throw new AtolOnlineException("Response code:" + response.StatusCode + ", Response text:" + response.Content);

        }


        public DocumentResponse Outcome(Document document)
        {
            RestRequest request = new RestRequest("outcome", Method.POST);
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