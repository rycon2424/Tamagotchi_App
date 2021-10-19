using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Options";
            deleteAndReset = new Command(DeletePet);
        }

        private Command deleteAndReset;

        public ICommand DeleteAndReset
        {
            get
            {
                return deleteAndReset;
            }
        }

        private void DeletePet()
        {
            Preferences.Set("InPlayGround", false);
            Pet.PetInstance.DeletePet(); 
        }
    }
}