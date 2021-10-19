using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTest
{
    public class LocalCreatureStore : IDataStore<Pet>
    {
        public Task<bool> CreateItem(Pet item)
        {
            string pet = JsonConvert.SerializeObject(this);
            Preferences.Set("MyPet", pet);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItem(Pet item)
        {
            Preferences.Remove("MyPet");

            return Task.FromResult(true);
        }

        public Task<Pet> ReadItem()
        {
            string petStats = Preferences.Get("MyPet", "");
            Pet pet = JsonConvert.DeserializeObject<Pet>(petStats);
            return Task.FromResult(pet);
        }

        public Task<bool> UpdateItem(Pet item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                string pet = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", pet);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> RemoveFromPlayGround()
        {
            return Task.FromResult(true);
        }

        public Task<bool> SendToPlayGround(Pet item)
        {
            return Task.FromResult(true);
        }
        public Task<PetObject> GetInfoFromPlayGround()
        {
            PetObject po = new PetObject();
            return Task.FromResult(po);
        }
    }
}
