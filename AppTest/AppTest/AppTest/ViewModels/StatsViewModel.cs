using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
using AppTest.Views;

namespace AppTest.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        string foodValue, drinkValue, bedValue, lonelyValue, funValue, excitementValue;
        public StatsViewModel()
        {
            Title = "Stats Overview";
            ShowStatsModel.OnStateUpdate += UpdateValues;
            UpdateValues();
        }

        public void UpdateValues()
        {
            FoodValue = GetPercentage(Pet.PetInstance.hunger, false);
            DrinkValue = GetPercentage(Pet.PetInstance.thirst, false);
            BedValue = GetPercentage(Pet.PetInstance.tired, false);
            LonelyValue = GetPercentage(Pet.PetInstance.loneliness, false);
            FunValue = GetPercentage(Pet.PetInstance.boredom, false);
            ExcitementValue = GetPercentage(Pet.PetInstance.stimulated, true);
        }

        string GetPercentage(Stat s, bool inverse)
        {
            string temp = "";
            if (inverse)
            {
                //temp = Math.Round((Convert.ToDecimal(s.StatValue * 100)) - 100 * -1, 0).ToString();
                int tempInt = (int)Math.Round(Convert.ToDecimal(s.StatValue * 100), 0);
                tempInt = (tempInt - 100) * -1;
                temp = tempInt.ToString();
            }
            else
                temp = Math.Round(Convert.ToDecimal(s.StatValue * 100), 0).ToString();
            temp += "%";
            return temp;
        }

        public string FoodValue
        {
            set
            {
                SetProperty(ref foodValue, value);
            }
            get => foodValue;
        }
        public string DrinkValue
        {
            set
            {
                SetProperty(ref drinkValue, value);
            }
            get => drinkValue;
        }
        public string BedValue
        {
            set
            {
                SetProperty(ref bedValue, value);
            }
            get => bedValue;
        }
        public string LonelyValue
        {
            set
            {
                SetProperty(ref lonelyValue, value);
            }
            get => lonelyValue;
        }
        public string FunValue
        {
            set
            {
                SetProperty(ref funValue, value);
            }
            get => funValue;
        }
        public string ExcitementValue
        {
            set
            {
                SetProperty(ref excitementValue, value);
            }
            get => excitementValue;
        }

    }
}