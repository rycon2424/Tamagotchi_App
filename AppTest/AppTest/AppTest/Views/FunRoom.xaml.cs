using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.Models;
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
        public override void RefreshContent()
        {
            if (Pet.Instance.sleeping == false)
            {
                List<GridButton> temp = new List<GridButton>();

                Button petButton = CreateButton("Play", 16);
                petButton.Clicked += Play;

                temp.Add(new GridButton(petButton, 1, 2));
                Content = Icons(temp);
            }
            else
            {
                Content = Icons(null);
            }
        }

        public void Play(object sender, EventArgs args)
        {
            Pet.Instance.boredom.StatValue += 0.1f;
            RefreshContent();
        }
    }
}