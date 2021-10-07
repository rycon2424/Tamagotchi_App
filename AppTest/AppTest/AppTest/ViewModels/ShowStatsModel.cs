using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class ShowStatsModel : BaseViewModel
    {
        public Stat food;
        public Stat drink;

        public ShowStatsModel()
        {
            food = new Stat("Food", 1f, Stat.TypeStat.hunger);
            drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
        }

        public void UpdateStat(Stat stat, float gainingValue)
        {
            stat.StatValue += gainingValue;
            stat.UpdateColor();
            switch (stat.StatType)
            {
                case Stat.TypeStat.hunger:
                    FoodState = new Color(1, 1, 1);
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

        //private string lol;

        public string Lol
        {
            get;
            set;
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