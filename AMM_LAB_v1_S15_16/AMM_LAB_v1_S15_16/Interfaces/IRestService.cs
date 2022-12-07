using AMM_LAB_v1_S15_16.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AMM_LAB_v1_S15_16.Interfaces
{
    public interface IRestService
    {
        Task<List<Product>> RefreshDataAsync();
        Task SaveProductItemAsync(Product item, bool isNewItem);
    }
}
