using AppTest.Services;
using AppTest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace AppTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Saved!");
            Pet.Instance.SaveStats();
        }

        protected override void OnResume()
        {
        }
    }
}
