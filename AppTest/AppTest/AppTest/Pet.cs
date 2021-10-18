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

        public int ID { get => id; set => id = value; }

        public int id;
        public string name = "Test";
        public Stat hunger = new Stat("Food", 1f, Stat.TypeStat.hunger);
        public Stat thirst = new Stat("Drink", 1f, Stat.TypeStat.thirst);
        public Stat tired = new Stat("Sleep", 1f, Stat.TypeStat.sleep);
        public Stat boredom = new Stat("Boredom", 1f, Stat.TypeStat.bored);
        public Stat stimulated = new Stat("Excitedment", 1f, Stat.TypeStat.excited);
        public Stat loneliness = new Stat("Lonelyness", 1f, Stat.TypeStat.lonely);

        public bool sleeping;

        public bool initialized = false;
        public IDataStore<Pet> dataStore;

        public Pet()
        {
            dataStore = DependencyService.Get<IDataStore<Pet>>();
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

        public async void LoadStats()
        {
            Pet pet = await dataStore.ReadItem();
            if (pet != null)
            {
                Debug.WriteLine("Found Save File!");

                hunger = pet.hunger;
                thirst = pet.thirst;
                tired = pet.tired;
                boredom = pet.boredom;
                stimulated = pet.stimulated;
                loneliness = pet.loneliness;
                sleeping = pet.sleeping;

                if (hunger.StatValue <= 0)
                    hunger.StatValue = 0.01f;
                if (thirst.StatValue <= 0)
                    thirst.StatValue = 0.01f;
                if (tired.StatValue <= 0)
                    tired.StatValue = 0.01f;
                if (boredom.StatValue <= 0)
                    boredom.StatValue = 0.01f;
                if (stimulated.StatValue <= 0)
                    stimulated.StatValue = 0.01f;
                if (loneliness.StatValue <= 0)
                    loneliness.StatValue = 0.01f;
            }
            else
            {
                Debug.WriteLine("Found NO Save File!");

                await dataStore.CreateItem(this);
            }
            initialized = true;
        }

        public void SaveStats()
        {
            dataStore.UpdateItem(this);
        }
    }
}
