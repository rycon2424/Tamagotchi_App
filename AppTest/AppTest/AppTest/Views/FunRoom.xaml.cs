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
        Random rnd = new Random();
        int buttonLocation = 1;

        public FunRoom()
        {
            InitializeComponent();
            BindingContext = new FunroomViewModel();
            RefreshContent();
        }
        public override void RefreshContent()
        {
            if (Pet.PetInstance.sleeping || Pet.PetInstance.inPlayGround)
            {
                Content = Icons(null);
            }
            else
            {
                List<GridButton> temp = new List<GridButton>();

                Button petButton = CreateButton("Play", 16);
                petButton.Clicked += Play;

                temp.Add(new GridButton(petButton, buttonLocation, 2));
                Content = Icons(temp);
            }
        }

        public void Play(object sender, EventArgs args)
        {
            if (Pet.PetInstance.stimulated.StatValue <= 0)
            {
                return;
            }
            UpdateVisuals(Pet.PetInstance.stimulated, -0.1f);
            UpdateVisuals(Pet.PetInstance.boredom, 0.05f);
            int temp = rnd.Next(0, 100);
            if (temp > 75)
                buttonLocation = 1;
            else if (temp > 50)
                buttonLocation = 4;
            else if (temp > 25)
                buttonLocation = 0;
            else if (temp >= 0)
                buttonLocation = 5;
            RefreshContent();
        }
    }
}