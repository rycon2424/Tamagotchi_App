using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppTest
{
    public class Pet
    {
        private static Pet instance = null;
        private static readonly object padlock = new object();

        public bool sleeping;

        public Stat food = new Stat("Food", 1f, Stat.TypeStat.hunger);
        public Stat drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
        public Stat sleep = new Stat("Sleep", 1f, Stat.TypeStat.sleep);
        public Stat boredom = new Stat("Boredom", 1f, Stat.TypeStat.bored);
        public Stat excited = new Stat("Excitedment", 1f, Stat.TypeStat.excited);
        public Stat lonely = new Stat("Lonelyness", 1f, Stat.TypeStat.lonely);

        public bool initialized = false;
        public IDataStore<Pet> localDataStore;

        public Pet()
        {
            localDataStore = DependencyService.Get<IDataStore<Pet>>();
        }

        public static Pet PetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Pet();
                    }
                    return instance;
                }
            }
        }

        public void LoadStats()
        {
            Pet pet = localDataStore.ReadItem();
            if (pet != null)
            {
                Debug.WriteLine("Found Save File!");

                food = pet.food;
                drink = pet.drink;
                sleep = pet.sleep;
                boredom = pet.boredom;
                excited = pet.excited;
                lonely = pet.lonely;
                sleeping = pet.sleeping;

                if (food.StatValue <= 0)
                    food.StatValue = 0.01f;
                if (drink.StatValue <= 0)
                    drink.StatValue = 0.01f;
                if (sleep.StatValue <= 0)
                    sleep.StatValue = 0.01f;
                if (boredom.StatValue <= 0)
                    boredom.StatValue = 0.01f;
                if (excited.StatValue <= 0)
                    excited.StatValue = 0.01f;
                if (lonely.StatValue <= 0)
                    lonely.StatValue = 0.01f;
            }
            else
            {
                localDataStore.CreateItem(this);
            }
            initialized = true;
        }

        public void SaveStats()
        {
            localDataStore.UpdateItem(this);
        }
    }
}
