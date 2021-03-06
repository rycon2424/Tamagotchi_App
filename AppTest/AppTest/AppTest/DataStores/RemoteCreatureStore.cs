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
    public class RemoteCreatureStore : IDataStore<PetObject>
    {
        private HttpClient client = new HttpClient();

        public async Task<bool> CreateItem(PetObject item) // POST
        {
            string pet = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(pet, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var postedPetAsText = await response.Content.ReadAsStringAsync();

                    PetObject postedPet = JsonConvert.DeserializeObject<PetObject>(postedPetAsText);

                    Debug.WriteLine("Create Pet with ID " + postedPet.id);

                    Preferences.Set("MyPetID", postedPet.id);

                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed " + response.StatusCode);
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public Task<bool> DeleteItem(PetObject item) // DELETE
        {
            Preferences.Remove("MyPetID");
            return Task.FromResult(true);
        }

        public async Task<PetObject> ReadItem() // GET
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return null;
            }

            var response = await client.GetAsync("https://tamagotchi.hku.nl/api/Creatures/" + petID);
            if (response.IsSuccessStatusCode)
            {
                string petAsText = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("Retrieving pet in api = " + petAsText + " ....");

                PetObject pet = JsonConvert.DeserializeObject<PetObject>(petAsText);

                Debug.WriteLine("Retrieving pet = " + petAsText + " successfull");

                return pet;
            }

            return null;

        }

        public async Task<bool> UpdateItem(PetObject item) // PUT
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return false;
            }

            item.id = petID;
            string pet = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PutAsync("https://tamagotchi.hku.nl/api/Creatures/" + petID, new StringContent(pet, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully updated pet in database");
                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed to update pet in database https://tamagotchi.hku.nl/api/Creatures/" + petID + " " + response.StatusCode);
                    return false;
                }
            }
            catch (HttpRequestException h)
            {
                Debug.WriteLine("failed with error code " + h.Message);
                return false;
            }
        }

        public async Task<bool> SendToPlayGround(PetObject item)
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return false;
            }

            string pet = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Playground/" + petID, new StringContent(pet, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var postedPetAsText = await response.Content.ReadAsStringAsync();

                    PetObject postedPet = JsonConvert.DeserializeObject<PetObject>(postedPetAsText);

                    Debug.WriteLine("Put Pet with ID in the playground");

                    Pet.PetInstance.inPlayGround = true;
                    Preferences.Set("InPlayGround", true);

                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed " + response.StatusCode);
                    return false;
                }
            }
            catch (HttpRequestException h)
            {
                Debug.WriteLine("failed with error code " + h.Message);
                return false;
            }
        }

        public async Task<bool> RemoveFromPlayGround()
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return false;
            }

            try
            {
                var response = await client.DeleteAsync("https://tamagotchi.hku.nl/api/Playground/" + petID);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Deleted Pet");
                    Pet.PetInstance.inPlayGround = false;
                    Preferences.Set("InPlayGround", false);
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Could not find pet {petID}, Failed " + response.StatusCode);
                    return false;
                }
            }
            catch (HttpRequestException h)
            {
                Debug.WriteLine("failed with error code " + h.Message);
                return false;
            }
        }

        public async Task<PetObject> GetInfoFromPlayGround()
        {
            int petID = Preferences.Get("MyPetID", 0);
            if (petID == 0)
            {
                return null;
            }

            var response = await client.GetAsync("https://tamagotchi.hku.nl/api/Playground/" + petID);
            if (response.IsSuccessStatusCode)
            {
                string petAsText = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("Retrieving pet in api = " + petAsText + " ....");

                PetObject pet = JsonConvert.DeserializeObject<PetObject>(petAsText);

                Debug.WriteLine("Pet retrieved time = " + pet.enterTime);

                return pet;
            }

            return null;
        }
    }
}
