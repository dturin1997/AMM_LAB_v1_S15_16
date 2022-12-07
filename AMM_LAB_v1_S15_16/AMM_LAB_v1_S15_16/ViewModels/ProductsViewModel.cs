using AMM_LAB_v1_S15_16.Services;
using AMM_LAB_v1_S15_16.Views;
using AMM_LAB_v1_S15_16.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMM_LAB_v1_S15_16.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Services        
        private readonly ProductService dataServiceProducts;
        #endregion Services

        #region Attributes

        private ObservableCollection<Product> products;

        #endregion Attributes

        #region Properties


        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }




        #endregion Properties

        #region Command

        public ICommand NewProductCommand
        {
            get
            {
                return new Command(NeWProduct);
            }
        }

        public ICommand LoadProductsCommand
        {
            get
            {
                return new Command(LoadProducts);
            }
        }
        /*
        public ICommand DeleteStudentCommand
        {
            get
            {
                return new Command((x) =>
                {
                    var item = (x as Student);
                    DeleteStudent(item);
                });
            }
            //get;
            //set;
        }
        */
        public ICommand UpdateProductCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Product);
                    await UpdateProduct(item);
                });
            }
        }
        
        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            this.dataServiceProducts = new ProductService();

            this.LoadProducts();

        }
        #endregion Constructor



        #region Methods
        
        private void NeWProduct()
        {
            Product product = new Product();
            //product.Id = 0;
            /*
            product.Name = "";
            product.Description = "";
            product.ExpirationDate = DateTime.Today;
            product.IsNew = false;
            */
            Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

            LoadProducts();

        }
        
        private async Task UpdateProduct(Product product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

        }
        /*
        private void DeleteStudent(Student student)
        {

            this.dataServiceStudents.Delete(student);
            LoadStudents();
        }
        */
        public async void LoadProducts()
        {
            var productsRest = await this.dataServiceProducts.RefreshDataAsync();
            this.Products = new ObservableCollection<Product>(productsRest);
            /*
            this.Products = new ObservableCollection<Product>();
            foreach (var item in productsRest)
                Products.Add(item);
            */
        }
        #endregion Methods
    }
}
