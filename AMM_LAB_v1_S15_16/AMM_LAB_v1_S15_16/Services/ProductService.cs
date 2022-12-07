using AMM_LAB_v1_S15_16.Interfaces;
using AMM_LAB_v1_S15_16.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AMM_LAB_v1_S15_16.Services
{
    public class ProductService : IRestService
    {
        HttpClient client;

        public List<Product> Items { get; private set; }

        public ProductService()
        {
#if DEBUG
            this.client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }
        public async Task<List<Product>> RefreshDataAsync()
        {
            Items = new List<Product>();
            string action = "Get";

            //http:xxxx/miapi/product/get
            var uri = new Uri(string.Format(Constants.RestUrl, action));
            try
            {

                HttpResponseMessage response = await client.GetAsync(uri);
                var prueba = response.IsSuccessStatusCode;
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    //Request es un JSON, te toca deserializar
                    Items = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                Console.WriteLine(ex.Message);
            }

            return Items;
        }
    }
}
