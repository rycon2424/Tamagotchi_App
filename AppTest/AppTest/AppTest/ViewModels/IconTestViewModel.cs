using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class IconTestViewModel : BaseViewModel
    {
        Stat food;
        Stat drink;
        List<Stat> allStats = new List<Stat>();
        public IconTestViewModel()
        {
            Title = "Icon";
            allStats.Add(food = new Stat("Food", 1f));
            allStats.Add(drink = new Stat("Drink", 1f));
            ReduceStats();
        }

        async void ReduceStats()
        {
            do
            {
                foreach (var s in allStats)
                {
                    if (s.StatValue > 0)
                    {
                        s.StatValue -= 0.1f;
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            } while (true);
        }

        public Color FoodState
        {
            get
            {
                return food.StatColor;
            }
        }
        public Color DrinkState
        {
            get
            {
                return drink.StatColor;
            }
        }

    }
}