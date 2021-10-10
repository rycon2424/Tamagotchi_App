using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class ShowStatsModel : BaseViewModel
    {
        public static Stat food = new Stat("Food", 1f, Stat.TypeStat.hunger);
        public static Stat drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);

        public ShowStatsModel()
        {
            TestUpdate();
        }

        async void TestUpdate()
        {
            while (true)
            {
                if (food != null)
                {
                    UpdateStat(food, -0.01f);
                }
                Lol += "x";
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
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