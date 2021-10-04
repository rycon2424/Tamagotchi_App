using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class TestPageViewModel : BaseViewModel
    {
        public TestPageViewModel()
        {
            Title = "Test";
            GetImage = "okman.png";
        }

        public string GetImage { get; set; }
    }
}