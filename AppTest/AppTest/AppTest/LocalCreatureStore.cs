using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AppTest
{
    public class LocalCreatureStore : IDataStore<Pet>
    {
        public bool CreateItem(Pet item)
        {
            string pet = JsonConvert.SerializeObject(this);
            Preferences.Set("MyPet", pet);
            return true;
        }

        public bool DeleteItem(Pet item)
        {
            Preferences.Remove("MyPet");

            return true;
        }

        public Pet ReadItem()
        {
            string petStats = Preferences.Get("MyPet", "");
            Pet pet = JsonConvert.DeserializeObject<Pet>(petStats);
            return pet;
        }

        public bool UpdateItem(Pet item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                string pet = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", pet);
                return true;
            }
            return false;
        }
    }
}
