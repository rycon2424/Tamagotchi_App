using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using AppTest.Views;

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
                PetStatsHandler.OnVisualUpdate += UpdateStat;
                Pet.PetInstance.OnLoadPet += InitializeDecay;
            }
        }

        public void InitializeDecay()
        {
            DecayStat(Pet.PetInstance.hunger, 5f, -0.01f);
            DecayStat(Pet.PetInstance.thirst, 3f, -0.01f);
            DecayStat(Pet.PetInstance.tired, 20f, -0.01f);
            DecayStat(Pet.PetInstance.boredom, 10f, -0.01f);
            DecayStat(Pet.PetInstance.loneliness, 12f, -0.01f);

            GainSleep();

            UpdateStat(Pet.PetInstance.stimulated, 0);

            OnStateUpdate();
        }

        async void DecayStat(Stat decayingStat, float secondsBetweenDecay, float decayValue)
        {
            while (true)
            {
                if (decayingStat != null)
                {
                    if (decayingStat.StatValue > 0)
                    {
                        UpdateStat(decayingStat, decayValue);
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(secondsBetweenDecay));
            }
        }

        async void GainSleep()
        {
            while (true)
            {
                if (Pet.PetInstance.sleeping)
                {
                    Pet.PetInstance.tired.StatValue += 0.05f;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public void UpdateStat(Stat stat, float decayValue)
        {
            stat.StatValue += decayValue;
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
            OnStateUpdate();
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
                Color _ = Pet.PetInstance.hunger.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.hunger.StatValue = RoundState(Pet.PetInstance.hunger);
                return Pet.PetInstance.hunger.StatColor;
            }
        }
        public Color DrinkState
        {
            set
            {
                Color _ = Pet.PetInstance.thirst.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.thirst.StatValue = RoundState(Pet.PetInstance.thirst);
                return Pet.PetInstance.thirst.StatColor;
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
                Color _ = Pet.PetInstance.tired.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.tired.StatValue = RoundState(Pet.PetInstance.tired);
                return Pet.PetInstance.tired.StatColor;
            }
        }

        public Color LonelynessState
        {
            set
            {
                Color _ = Pet.PetInstance.loneliness.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.loneliness.StatValue = RoundState(Pet.PetInstance.loneliness);
                return Pet.PetInstance.loneliness.StatColor;
            }
        }

        public Color ExcitedmentState
        {
            set
            {
                Color _ = Pet.PetInstance.stimulated.StatColor;
                SetProperty(ref _, value);
            }
            get
            {
                Pet.PetInstance.stimulated.StatValue = RoundState(Pet.PetInstance.stimulated);
                return Pet.PetInstance.stimulated.StatColor;
            }
        }
    }
}