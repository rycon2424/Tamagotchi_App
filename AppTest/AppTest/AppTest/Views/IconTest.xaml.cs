using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconTest : ContentPage
    {
        public IconTest()
        {
            InitializeComponent();
            BindingContext = new IconTestViewModel();
        }
    }
}