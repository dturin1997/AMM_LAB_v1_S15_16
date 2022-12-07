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
                //Console.WriteLine(ex);
                Debug.WriteLine(@"\tERROR {0}", ex);
                System.Console.WriteLine(ex);
            }

            return Items;
        }

        public async Task SaveProductItemAsync(Product item, bool isNewItem)
        {
            try
            {
                //Response es un objeto.
                //Serializar
                var id = item.id;
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    var uri = new Uri(string.Format(Constants.RestUrl, "Create"));
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constants.RestUrl+$"{id}", "Edit"));
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tProduct successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {1}", ex.Message);
            }
        }

        public async Task DeleteProductItemAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl + $"{id}", "Delete"));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
