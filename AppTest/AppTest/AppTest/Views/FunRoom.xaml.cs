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
    public partial class FunRoom : PetStatsHandler
    {
        public FunRoom()
        {
            InitializeComponent();
            BindingContext = new FunroomViewModel();
            RefreshContent();
        }
    }
}