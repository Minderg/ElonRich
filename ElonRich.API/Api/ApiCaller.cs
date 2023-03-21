using ElonRich.API.Models.Launch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElonRich.API.Models.Launch.LaunchModel;

namespace ElonRich.API.Api
{
    public class ApiCaller
    {
        public async Task<List<ElonRich.API.Models.Launch.LaunchModel.Root>?> GetAllLaunches()
        {
            var client = await ApiInitializer.HttpClient.GetAsync("https://api.spacexdata.com/v3/launches");
            var response = await client.Content.ReadAsStringAsync();
            List <ElonRich.API.Models.Launch.LaunchModel.Root> result = JsonConvert.DeserializeObject<List<ElonRich.API.Models.Launch.LaunchModel.Root>>(response);

            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<List<ElonRich.API.Models.Rocket.RocketModel.Root>?> GetAllRockets()
        {
            var client = await ApiInitializer.HttpClient.GetAsync("https://api.spacexdata.com/v3/rockets");
            var response = await client.Content.ReadAsStringAsync();
            List<ElonRich.API.Models.Rocket.RocketModel.Root> result = JsonConvert.DeserializeObject<List<ElonRich.API.Models.Rocket.RocketModel.Root>>(response);

            if(result != null)
            {
                return result;
            }

            return null;
        }
    }
}
