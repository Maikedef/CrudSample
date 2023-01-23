using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Xunit;

namespace CrudSample.Test
{
    public class ControllerBase : IClassFixture<CrudSampleWebApplicationFactory<Program>>
    {

        private readonly HttpClient _httpClient;

        public ControllerBase(CrudSampleWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        protected async Task<HttpResponseMessage> PostRequest(string metodo, object body, string autorization = "")
        {
            var jsonString = JsonConvert.SerializeObject(body);

            if (!string.IsNullOrEmpty(autorization))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorization);
            }

            return await _httpClient.PostAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        protected async Task<HttpResponseMessage> PutRequest(string metodo, object body, string autorization = "")
        {
            var jsonString = JsonConvert.SerializeObject(body);

            if (!string.IsNullOrEmpty(autorization))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorization);
            }

            return await _httpClient.PutAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        protected async Task<HttpResponseMessage> DeleteRequest(string metodo, string autorization = "")
        {
            if (!string.IsNullOrEmpty(autorization))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorization);
            }

            return await _httpClient.DeleteAsync(metodo);
        }

        protected async Task<HttpResponseMessage> GetRequestQuery(string metodo, string parametroName,string parametroValue, string autorization = "")
        {
            if (!string.IsNullOrEmpty(autorization))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorization);
            }

            var query = HttpUtility.ParseQueryString("?");
            query[parametroName] = parametroValue;
            string queryString = query.ToString();

            return await _httpClient.GetAsync(metodo + queryString);
        }

        protected async Task<HttpResponseMessage> GetRequestRoute(string metodo, string autorization = "")
        {
            if (!string.IsNullOrEmpty(autorization))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorization);
            }

            return await _httpClient.GetAsync(metodo);
        }
    }
}
