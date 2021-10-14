using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppTest
{
    public class Pet
    {
        private static Pet instance = null;
        private static readonly object padlock = new object();

        public Stat food = new Stat("Food", 1f, Stat.TypeStat.hunger);
        public Stat drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
        public Stat sleep = new Stat("Sleep", 1f, Stat.TypeStat.sleep);
        public Stat boredom = new Stat("Boredom", 1f, Stat.TypeStat.bored);
        public Stat excited = new Stat("Excitedment", 1f, Stat.TypeStat.excited);
        public Stat lonely = new Stat("Lonelyness", 1f, Stat.TypeStat.lonely);

        public bool initialized = false;

        public Pet()
        {

        }

        public static Pet Instance
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
            food = new Stat("Food", 1f, Stat.TypeStat.hunger);
            drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
            sleep = new Stat("Sleep", 1f, Stat.TypeStat.sleep);
            boredom = new Stat("Boredom", 1f, Stat.TypeStat.bored);
            excited = new Stat("Excitedment", 1f, Stat.TypeStat.excited);
            lonely = new Stat("Lonelyness", 1f, Stat.TypeStat.lonely);
            initialized = true;
        }
        public void SaveStats()
        {

        }
    }
}
