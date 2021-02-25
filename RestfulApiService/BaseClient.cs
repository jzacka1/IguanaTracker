using RestSharp;
using System;

namespace RestfulApiService
{
	public class BaseClient : RestClient
	{
        protected string _baseURL { get; set; }

        public BaseClient(string baseUrl)
        {
            //_cache = cache;
            //_cache = new InMemoryCache();
            //_serializer = serializer;
            //_errorLogger = errorLogger;
            //AddHandler("application/json", JsonSerializer.Default);
            //AddHandler("text/json", JsonSerializer.Default);
            //AddHandler("text/x-json", JsonSerializer.Default);
            BaseUrl = new Uri(baseUrl);
        }

        public override IRestResponse Execute(IRestRequest request)
        {
            var response = base.Execute(request);
            //TimeoutCheck(request, response);
            return response;
        }
        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            var response = base.Execute<T>(request);
            //TimeoutCheck(request, response);
            return response;
        }

        public T Get<T>(IRestRequest request) where T : new(){
            var response = Execute<T>(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? response.Data : default;
        }
    }
}
