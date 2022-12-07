using AMM_LAB_v1_S15_16.Interfaces;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMM_LAB_v1_S15_16.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace AMM_LAB_v1_S15_16.Droid
{
    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                {
                    if (cert.Issuer.Equals("CN=localhost"))
                        return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                };
            return handler;
        }
    }
}