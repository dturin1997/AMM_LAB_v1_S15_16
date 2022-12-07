using AMM_LAB_v1_S15_16.ViewModels;
using AMM_LAB_v1_S15_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMM_LAB_v1_S15_16.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage(Product product)
        {
            InitializeComponent();
            this.BindingContext = new ProductViewModel(product);
        }
    }
}