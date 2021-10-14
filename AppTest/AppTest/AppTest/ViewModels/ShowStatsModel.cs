using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AppTest.ViewModels
{
    public class ShowStatsModel : BaseViewModel
    {
        public delegate void StatUpdate();
        public static event StatUpdate OnStateUpdate;

        public ShowStatsModel()
        {
            if (Pet.Instance.initialized == false)
            {
                Pet.Instance.LoadStats();
                Initialize();
            }
        }

        void Initialize()
        {
            DecayStat(Pet.Instance.food, 1.5f);
            DecayStat(Pet.Instance.drink, 1f);
            DecayStat(Pet.Instance.sleep, 10f);
            DecayStat(Pet.Instance.boredom, 5f);
            DecayStat(Pet.Instance.excited, 0.5f);
            DecayStat(Pet.Instance.lonely, 3f);
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
        public void SaveStats(Pet p)
        {
            string petText = JsonConvert.SerializeObject(p);
        }

        //public Pet LoadStat()
        //{
        //    Pet p = JsonConvert.DeserializeObject<Pet>();
        //    return p;
        //}

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
                Color _ = Pet.Instance.food.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.food.StatValue = RoundState(Pet.Instance.food);
                return Pet.Instance.food.StatColor;
            }
        }
        public Color DrinkState
        {
            set
            {
                Color _ = Pet.Instance.drink.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.drink.StatValue = RoundState(Pet.Instance.drink);
                return Pet.Instance.drink.StatColor;
            }
        }

        public Color BoredomState
        {
            set
            {
                Color _ = Pet.Instance.boredom.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.boredom.StatValue = RoundState(Pet.Instance.boredom);
                return Pet.Instance.boredom.StatColor;
            }
        }

        public Color SleepState
        {
            set
            {
                Color _ = Pet.Instance.sleep.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.sleep.StatValue = RoundState(Pet.Instance.sleep);
                return Pet.Instance.sleep.StatColor;
            }
        }

        public Color LonelynessState
        {
            set
            {
                Color _ = Pet.Instance.lonely.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.lonely.StatValue = RoundState(Pet.Instance.lonely);
                return Pet.Instance.lonely.StatColor;
            }
        }

        public Color ExcitedmentState
        {
            set
            {
                Color _ = Pet.Instance.excited.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.Instance.excited.StatValue = RoundState(Pet.Instance.excited);
                return Pet.Instance.excited.StatColor;
            }
        }

    }
}