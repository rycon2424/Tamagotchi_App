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


                string buttonName = "";
                if (Pet.PetInstance.inPlayGround)
                {
                    buttonName = "Get From PlayGround";
                }
                else
                {
                    buttonName = "To PlayGround";
                    Button petButton = CreateButton("Pet", 16);
                    temp.Add(new GridButton(petButton, 1, 2));
                    petButton.Clicked += PetPet;
                }
                Button toPlayGround = CreateButton(buttonName, 6);

                toPlayGround.Scale = 2f;
                toPlayGround.AnchorX = 0.05;

                if (Pet.PetInstance.inPlayGround)
                    toPlayGround.Clicked += RetrievePetFromPlayGround;
                else
                    toPlayGround.Clicked += SendPetToPlayGround;

                temp.Add(new GridButton(toPlayGround, 4, 2));

                Content = Icons(temp);
            }
            else
            {
                Content = Icons(null);
            }
        }

        public void PetPet(object sender, EventArgs args)
        {
            if (Pet.PetInstance.stimulated.StatValue <= 0)
            {
                return;
            }
            UpdateVisuals(Pet.PetInstance.stimulated, -0.05f);
            UpdateVisuals(Pet.PetInstance.loneliness, 0.1f);
            RefreshContent();
        }

        public async void SendPetToPlayGround(object sender, EventArgs args)
        {
            PetObject pet = new PetObject();
            pet.UpdateStats(Pet.PetInstance);
            await Pet.PetInstance.dataStore.SendToPlayGround(pet);
            AllPages.UpdateAllPages();
            RefreshContent();
        }

        public async void RetrievePetFromPlayGround(object sender, EventArgs args)
        {
            await Pet.PetInstance.dataStore.RemoveFromPlayGround();
            AllPages.UpdateAllPages();
            RefreshContent();
        }
    }
}