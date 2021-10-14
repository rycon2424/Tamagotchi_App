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
        }

        public void UpdateValues()
        {
            FoodValue = GetPercentage(Pet.Instance.food);
            DrinkValue = GetPercentage(Pet.Instance.drink);
            BedValue = GetPercentage(Pet.Instance.sleep);
            LonelyValue = GetPercentage(Pet.Instance.lonely);
            FunValue = GetPercentage(Pet.Instance.boredom);
            ExcitementValue = GetPercentage(Pet.Instance.excited);
        }

        string GetPercentage(Stat s)
        {
            string temp = (Math.Round(Convert.ToDecimal(s.StatValue * 100), 0).ToString());
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