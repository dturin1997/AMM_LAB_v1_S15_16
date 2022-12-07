using AMM_LAB_v1_S15_16.Services;
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
/*
        public ICommand NeWStudentCommand
        {
            get
            {
                return new Command(NeWStudent);
            }
        }
*/
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
        
        public ICommand UpdateStudentCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Student);
                    await UpdateStudent(item);
                });
            }
        }
        */
        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            this.dataServiceProducts = new ProductService();

            this.LoadProducts();

        }
        #endregion Constructor



        #region Methods
        /*
        private void NeWStudent()
        {
            Student student = new Student();
            student.StudentId = 0;
            student.LastName = "";
            student.FirstName = "";
            student.Adress = "";
            student.Edad = 0;

            Application.Current.MainPage.Navigation.PushAsync(new StudentPage(student));

            LoadStudents();

        }
        
        private async Task UpdateStudent(Student student)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StudentPage(student));

        }

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
