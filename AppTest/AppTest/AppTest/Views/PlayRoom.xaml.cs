using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.ViewModels;
using AppTest.Models;

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
        public override void RefreshContent()
        {
            if (Pet.PetInstance.sleeping == false)
            {
                List<GridButton> temp = new List<GridButton>();

                Button petButton = CreateButton("Pet", 16);
                Button tickleButton = CreateButton("Tickle", 12);
                petButton.Clicked += PetPet;
                tickleButton.Clicked += PetPet;

                temp.Add(new GridButton(petButton, 1, 2));
                temp.Add(new GridButton(tickleButton, 4, 2));
                Content = Icons(temp);
            }
            else
            {
                Content = Icons(null);
            }
        }

        public void PetPet(object sender, EventArgs args)
        {
            Pet.PetInstance.loneliness.StatValue += 0.1f;
            RefreshContent();
        }
    }
}