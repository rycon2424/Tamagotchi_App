using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace AppTest.ViewModels
{
    public class ShowStatsModel : BaseViewModel
    {
        public delegate void StatUpdate();
        public static event StatUpdate OnStateUpdate;

        public ShowStatsModel()
        {
            if (Pet.PetInstance.initialized == false)
            {
                Pet.PetInstance.LoadStats();
                InitializeDecay();
            }
        }

        void InitializeDecay()
        {
            DecayStat(Pet.PetInstance.food, 5f);
            DecayStat(Pet.PetInstance.drink, 3f);
            DecayStat(Pet.PetInstance.sleep, 20f);
            DecayStat(Pet.PetInstance.boredom, 10f);
            DecayStat(Pet.PetInstance.lonely, 12f);

            GainSleep();

            UpdateStat(Pet.PetInstance.excited);
        }

        async void DecayStat(Stat decayingStat, float secondsBetweenDecay)
        {
            while (true)
            {
                if (decayingStat != null)
                {
                    if (decayingStat.StatValue > 0)
                    {
                        UpdateStat(decayingStat);
                    }
                }
                OnStateUpdate();
                await Task.Delay(TimeSpan.FromSeconds(secondsBetweenDecay));
            }
        }

        async void GainSleep()
        {
            while (true)
            {
                if (Pet.PetInstance.sleeping)
                {
                    Pet.PetInstance.sleep.StatValue += 0.05f;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public void UpdateStat(Stat stat)
        {
            stat.StatValue -= 0.01f;
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
            stat.UpdateColor();
        }

        float RoundState(Stat s)
        {
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
                Color _ = Pet.PetInstance.food.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.food.StatValue = RoundState(Pet.PetInstance.food);
                return Pet.PetInstance.food.StatColor;
            }
        }
        public Color DrinkState
        {
            set
            {
                Color _ = Pet.PetInstance.drink.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.drink.StatValue = RoundState(Pet.PetInstance.drink);
                return Pet.PetInstance.drink.StatColor;
            }
        }

        public Color BoredomState
        {
            set
            {
                Color _ = Pet.PetInstance.boredom.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.boredom.StatValue = RoundState(Pet.PetInstance.boredom);
                return Pet.PetInstance.boredom.StatColor;
            }
        }

        public Color SleepState
        {
            set
            {
                Color _ = Pet.PetInstance.sleep.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.sleep.StatValue = RoundState(Pet.PetInstance.sleep);
                return Pet.PetInstance.sleep.StatColor;
            }
        }

        public Color LonelynessState
        {
            set
            {
                Color _ = Pet.PetInstance.lonely.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.lonely.StatValue = RoundState(Pet.PetInstance.lonely);
                return Pet.PetInstance.lonely.StatColor;
            }
        }

        public Color ExcitedmentState
        {
            set
            {
                Color _ = Pet.PetInstance.excited.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.excited.StatValue = RoundState(Pet.PetInstance.excited);
                return Pet.PetInstance.excited.StatColor;
            }
        }
    }
}