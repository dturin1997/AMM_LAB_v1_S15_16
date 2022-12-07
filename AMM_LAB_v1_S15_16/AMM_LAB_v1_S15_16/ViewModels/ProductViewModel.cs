using AMM_LAB_v1_S15_16.Services;
using AMM_LAB_v1_S15_16.Views;
using AMM_LAB_v1_S15_16.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMM_LAB_v1_S15_16.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        #region Services
        private readonly ProductService dataServiceProducts;
        #endregion

        #region Attributes

        public bool exist;

        private string name;
        private string description;
        private string expirationdate;
        private bool isnew;
        private int stock;
        private Product product;
        #endregion

        #region Properties
        public Product Product
        {
            get { return this.product; }
            set { SetValue(ref this.product, value); }
        }
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public string Description
        {
            get { return this.description; }
            set { SetValue(ref this.description, value); }
        }
        public string ExpirationDate
        {
            get { return this.expirationdate; }
            set { SetValue(ref this.expirationdate, value); }
        }
        public bool IsNew
        {
            get { return this.isnew; }
            set { SetValue(ref this.isnew, value); }
        }
        public int Stock
        {
            get { return this.stock; }
            set { SetValue(ref this.stock, value); }
        }

        #endregion

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command<Product>(execute: async (product) =>
                {
                    
                    if (this.Product.id > 0) {
                        exist = false;
                    }
                    else
                    {
                        exist = true;
                    }

                    var newProduct = new Product()
                    {
                        id = this.Product.id,
                        name = this.Name,
                        description = this.Description,
                        //ExpirationDate = DateTime.Parse(this.ExpirationDate),
                        expirationDate = this.ExpirationDate,
                        isNew = this.IsNew,
                        stock = this.Stock,
                    };

                    await this.dataServiceProducts.SaveProductItemAsync(newProduct, exist);

                    await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
                    ProductsViewModel productsViewModel = new ProductsViewModel();
                    productsViewModel.LoadProducts();
                    /*
                    if (this.Product.Id > 0)
                    {

                        var newStudent = new Student()
                        {
                            StudentId = this.Student.StudentId,
                            LastName = this.LastName,
                            FirstName = this.FirstName,
                            Adress = this.Adress,
                            Edad = this.Edad
                        };

                        await this.dataServiceProducts.SaveProductItemAsync(newStudent);

                    }
                    else
                    {
                        var newStudent = new Student()
                        {
                            LastName = this.LastName,
                            FirstName = this.FirstName,
                            Adress = this.Adress,
                            Edad = this.Edad
                        };

                        await this.dataServiceProducts.SaveProductItemAsync(newStudent);
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }


                    await Application.Current.MainPage.Navigation.PushAsync(new StudentsPage());
                    StudentsViewModel studentsViewModel = new StudentsViewModel();
                    studentsViewModel.LoadStudents();
                    
                */
                });
            }
        }
        #endregion Commands

        #region Constructor
        public ProductViewModel(Product product)
        {
            this.dataServiceProducts = new ProductService();
            if (product != null)
            {
                this.Product = product;
                this.Name = product.name;
                this.Description = product.description;
                this.ExpirationDate = product.expirationDate;
                this.IsNew = product.isNew;
                this.Stock = product.stock;

            }
            else
            {
                this.Product = product;
                this.Name = "";
                this.Description = "";
                this.ExpirationDate = "" ;
                this.IsNew = false;
                this.Stock = 0;
            }
        }
        #endregion Constructor






        #region Methods

        #endregion
    }
}
