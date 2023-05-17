using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace Tofu.Services
{
    public class AnimalService
    {
        List<Animal> animals = new();
        HttpClient httpClient;

        public AnimalService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Animal>> GetAnimals()
        {
            var response = await httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                animals = await response.Content.ReadFromJsonAsync<List<Animal>>();
            }

            else
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("mockAnimals.json");
                var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                animals = JsonSerializer.Deserialize<List<Animal>>(contents);
            }
            return animals;
        }
    }
}
