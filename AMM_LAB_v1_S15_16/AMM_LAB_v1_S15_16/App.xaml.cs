using AMM_LAB_v1_S15_16.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMM_LAB_v1_S15_16
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ProductsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
