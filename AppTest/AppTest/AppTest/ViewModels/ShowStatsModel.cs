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
        public delegate void StatUpdate();
        public static event StatUpdate OnStateUpdate;

        public static Stat food = new Stat("Food", 1f, Stat.TypeStat.hunger);
        public static Stat drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
        public static Stat sleep = new Stat("Sleep", 1f, Stat.TypeStat.sleep);
        public static Stat boredom = new Stat("Boredom", 1f, Stat.TypeStat.bored);
        public static Stat excited = new Stat("Excitedment", 1f, Stat.TypeStat.excited);
        public static Stat lonely = new Stat("Lonelyness", 1f, Stat.TypeStat.lonely);

        public ShowStatsModel()
        {
            DecayStat(food, 1.5f);
            DecayStat(drink, 1f);
            DecayStat(sleep, 10f);
            DecayStat(boredom, 5f);
            DecayStat(excited, 0.5f);
            DecayStat(lonely, 3f);
        }

        async void DecayStat(Stat decayingStat, float secondsBetweenDecay)
        {
            while (true)
            {
                if (decayingStat != null)
                {
                    UpdateStat(decayingStat);
                }
                OnStateUpdate();
                await Task.Delay(TimeSpan.FromSeconds(secondsBetweenDecay));
            }
        }

        public void UpdateStat(Stat stat)
        {
            stat.UpdateColor();
            switch (stat.StatType)
            {
                case Stat.TypeStat.hunger:
                    FoodState = new Color(1, 1, 1);
                    break;
                case Stat.TypeStat.thirst:
                    DrinkState = new Color(1, 1, 1);
                    break;
                case Stat.TypeStat.bored:
                    BoredomState = new Color(1, 1, 1);
                    break;
                case Stat.TypeStat.lonely:
                    LonelynessState = new Color(1, 1, 1);
                    break;
                case Stat.TypeStat.excited:
                    ExcitedmentState = new Color(1, 1, 1);
                    break;
                case Stat.TypeStat.sleep:
                    SleepState = new Color(1, 1, 1);
                    break;
                default:
                    break;
            }
        }

        float RoundState(Stat s)
        {
            s.StatValue -= 0.01f;
            if (s.StatValue < 0)
            {
                s.StatValue = 0;
            }
            return s.StatValue;
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
                food.StatValue = RoundState(food);
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
                drink.StatValue = RoundState(drink);
                return drink.StatColor;
            }
        }

        public Color BoredomState
        {
            set
            {
                Color _ = boredom.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                boredom.StatValue = RoundState(boredom);
                return boredom.StatColor;
            }
        }

        public Color SleepState
        {
            set
            {
                Color _ = sleep.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                sleep.StatValue = RoundState(sleep);
                return sleep.StatColor;
            }
        }

        public Color LonelynessState
        {
            set
            {
                Color _ = lonely.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                lonely.StatValue = RoundState(lonely);
                return lonely.StatColor;
            }
        }

        public Color ExcitedmentState
        {
            set
            {
                Color _ = excited.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                excited.StatValue = RoundState(excited);
                return excited.StatColor;
            }
        }

    }
}