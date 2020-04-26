using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Bd.Web.App.HttpService;
using Bd.Web.App.WebApiClient;

namespace Bd.Web.App.WebApiClients
{
    public class ApiClient : IApiClient
    {
        private static HttpClient _httpClient;
        //private readonly IAuthenticationManager _authenticationManager;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private  string _accessToken;

        public ApiClient(/*IHttpContextAccessor httpContextAccessor*/)
        {
            _httpClient = HttpClientProvider.HttpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _accessToken = string.Empty;
            //_httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> DeleteAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync<T>(string uri)
        {

            var message =
                new HttpRequestMessage(HttpMethod.Get, $"{ _httpClient.BaseAddress}{uri}");
            //message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessTokenAsync());



            var response = await _httpClient.SendAsync(message);

            if (response != null && response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }

            HandleApiError(response);
            return default ;


        }

        public Task<T> GetAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> ListAsync<T>(string uri)
        {
            var message =
                new HttpRequestMessage(HttpMethod.Get, $"{uri}");
            //message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessTokenAsync());



                var response = await _httpClient.SendAsync(message);

                if (response != null && response.IsSuccessStatusCode)
                {

                    var jsonString = await response.Content.ReadAsStringAsync();

                    var listOfJsonT = JsonConvert.DeserializeObject<ICollection<T>>(jsonString);

                    var jsonRes = JsonConvert.SerializeObject(listOfJsonT, Formatting.None, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    listOfJsonT = JsonConvert.DeserializeObject<ICollection<T>>(jsonRes);
                    return listOfJsonT;
                }






            return default;



        }

        public Task<IEnumerable<T>> ListAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> PostAsync<T>(string uri, T newItem)
        {
            var message =
                new HttpRequestMessage(HttpMethod.Post, $"{uri}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8,
                        "application/json")
                };
           // message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessTokenAsync());

            var responseA = _httpClient.SendAsync(message);

            if (responseA != null && responseA.IsCompletedSuccessfully)
            {
                var jsonString = await responseA.Result.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(jsonString);
                return result;
            }

            //TODO: Fix the error 
            //HandleApiError(responseA);
            return default;

        }

        public Task PutAsync<T>(string uri, T updatedItem)
        {
            throw new NotImplementedException();
        }




        //private async Task<string> GetAccessTokenAsync()
        //{
        //    var currentContext = _httpContextAccessor.HttpContext;

        //    _accessToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        //    if (!string.IsNullOrWhiteSpace(_accessToken))
        //    {
        //        return _accessToken;
        //    }
        //    return null;

        //}

        private void HandleApiError(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }



        //private async Task<string> RenewTokens()
        //{
        //    var currentContext = _httpContextAccessor.HttpContext;
        //    //get the metadata
        //    var discoveryClient = new DiscoveryDocumentResponse();

        //    var client = new HttpClient();

        //    var metadataResponse = client.GetDiscoveryDocumentAsync("https://localhost:44314/");
        //    if (metadataResponse.IsFaulted)
        //    {
        //        throw new Exception(metadataResponse.Exception.Message);
        //    }

        //    //create a new token to get new token
        //    var tokenClient = await client.RequestTokenAsync(new TokenRequest
        //    {
        //        Address = "https://localhost:44314/",
        //        GrantType = "hybrid",

        //        ClientId = "BankAppClientId",
        //        ClientSecret = "secret",

        //        Parameters =
        //        {
        //            { "scope", $"{metadataResponse.Result.TokenEndpoint}" }
        //        }
        //    });
        //    //get the saved refresh token

        //    var currentRefreshToken = await currentContext.GetTokenAsync("oidc", "refresh_token");

        //    //refresh the token
        //    var tokenResult = tokenClient.RefreshToken;

        //    if (tokenResult.)
        //    {
                
        ////    }



        //    throw new NotImplementedException();
        //}
    }
}
