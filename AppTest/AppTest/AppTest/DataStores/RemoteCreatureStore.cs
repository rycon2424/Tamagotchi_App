using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTest
{
    public class RemoteCreatureStore : IDataStore<Pet>
    {
        private HttpClient client = new HttpClient();

        public async Task<bool> CreateItem(Pet item) // POST
        {
            string pet = JsonConvert.SerializeObject(this);

            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(pet, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var postedPetAsText = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("HMMMMMMMMMMMMMMMMMMMMM " + postedPetAsText);

                    Pet postedPet = JsonConvert.DeserializeObject<Pet>(postedPetAsText);

                    Debug.WriteLine("ID ============================ " + postedPet.ID);

                    Preferences.Set("MyPetID", postedPet.ID);

                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed");
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public Task<bool> DeleteItem(Pet item) // DELETE
        {
            return Task.FromResult(true);
        }

        public async Task<Pet> ReadItem() // GET
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return null;
            }

            var response = await client.GetAsync("https://tamagotchi.hku.nl/api/Creatures/2");
            if (response.IsSuccessStatusCode)
            {
                string petAsText = await response.Content.ReadAsStringAsync();

                Pet pet = JsonConvert.DeserializeObject<Pet>(petAsText);

                Preferences.Set("MyPetID", pet.ID);

                return pet;
            }

            return null;

        }

        public Task<bool> UpdateItem(Pet item) // PUT
        {
            return Task.FromResult(true);
        }
    }
}
