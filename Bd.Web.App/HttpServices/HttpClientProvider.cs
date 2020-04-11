using System;
using System.Net.Http;


namespace Bd.Web.App.HttpService
{
    public static class HttpClientProvider
    {
        //Todo : Change the base Address before production

        public static HttpClient HttpClient
        {
            get
            {
                return new HttpClient
                {
                    //BaseAddress = new Uri("https://localhost:44338/api/")
                    BaseAddress = new Uri("http://192.168.1.25:59168/api/")
                };
            }
        }
    }

}
