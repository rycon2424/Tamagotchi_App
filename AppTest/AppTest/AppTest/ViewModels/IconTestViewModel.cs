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
            allStats.Add(food = new Stat("Food", 1f, Stat.TypeStat.hunger));
            allStats.Add(drink = new Stat("Drink", 1f, Stat.TypeStat.thirst));
            TestUpdate();
        }

        void UpdateStat(Stat stat, float gainingValue)
        {
            stat.StatValue += gainingValue;
            stat.UpdateColor();
            switch (stat.StatType)
            {
                case Stat.TypeStat.hunger:
                    FoodState = new Color(1,1,1);
                    break;
                case Stat.TypeStat.thirst:
                    break;
                case Stat.TypeStat.bored:
                    break;
                case Stat.TypeStat.lonely:
                    break;
                case Stat.TypeStat.excited:
                    break;
                case Stat.TypeStat.sleep:
                    break;
                default:
                    break;
            }
        }

        async void TestUpdate()
        {
            while (true)
            {
                UpdateStat(food, -0.01f);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private string lol;

        public string Lol
        {
            set
            {
                SetProperty(ref lol, value);
            }
            get
            {
                return lol;
            }
        }

        public Color FoodState
        {
            set
            {
                Color _ = food.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                food.StatValue -= 0.1f;
                return food.StatColor;
            }
        }
        public Color DrinkState
        {
            set
            {
                Color _ = drink.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                return drink.StatColor;
            }
        }

    }
}