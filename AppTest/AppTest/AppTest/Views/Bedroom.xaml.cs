using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.ViewModels;
using AppTest.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

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
            if (Pet.PetInstance.inPlayGround == false)
            {
                List<GridButton> temp = new List<GridButton>();

                Button sleepButton = CreateButton("Lamp", 14);
                sleepButton.Clicked += SwapDayNightTime;

                temp.Add(new GridButton(sleepButton, 4, 2));
                Content = Icons(temp);
            }
            else
            {
                Content = Icons(null);
            }
        }

        public void SwapDayNightTime(object sender, EventArgs args)
        {
            Pet.PetInstance.sleeping = !Pet.PetInstance.sleeping;
            Preferences.Set("Sleeping", Pet.PetInstance.sleeping);
            Preferences.Set("TimeAsleep", DateTime.Now);

            AllPages.UpdateAllPages();

            RefreshContent();
        }
    }
}