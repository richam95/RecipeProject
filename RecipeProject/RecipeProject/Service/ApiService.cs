using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecipeProject.Service
{
    public class ApiService : IApiService
    {
        private static HttpClient client = null;

        private const string BaseUrl = "https://www.themealdb.com/";
        private const string Route = "api/json/";
        private const string Version = "v1/1/";
        private static HttpClient GetInstance()
        {
            try
            {
                if (client == null)
                {
                    client = new HttpClient()
                    {
                        BaseAddress = new Uri($"{BaseUrl}{Route}{Version}")
                    };
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }
            }
            catch (Exception ex) { }
            return client;

        }

        public async Task<string> GetApiResponse(string url)
        {
            try
            {
                HttpResponseMessage response = await GetInstance().GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return res;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    client.Dispose();
                    client = null;
                    return $"{Constants.ERROR} {response.ReasonPhrase}";
                }
                else
                {
                    return $"{Constants.ERROR} {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return $"{Constants.ERROR} {ex.Message}";
            }
        }
    }
}

