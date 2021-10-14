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
    public partial class Bedroom : PetStatsHandler
    {
        public Bedroom()
        {
            InitializeComponent();
            BindingContext = new BedroomViewModel();
            RefreshContent();
        }
        public override void RefreshContent()
        {
            Content = new StackLayout
            {
                Children =
                {
                    Icons(),
                    PetImage()
                }
            };
        }
    }
}