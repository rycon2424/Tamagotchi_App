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
    public partial class PlayRoom : PetStatsHandler
    {
        public PlayRoom()
        {
            InitializeComponent();
            BindingContext = new PlayroomViewModel();
            RefreshContent();
        }
    }
}