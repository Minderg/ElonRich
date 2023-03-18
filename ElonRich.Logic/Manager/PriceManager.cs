using ElonRich.API.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonRich.Logic.Manager
{
    public class PriceManager
    {
        public List<ElonRich.API.Models.Launch.LaunchModel.Root>? Launches { get; set; }
        public List<ElonRich.API.Models.Rocket.RocketModel.Root>? Rockets { get; set; }
        public decimal Price { get; set; }
        public async Task<decimal> CalculateTotalPrice(List<ElonRich.API.Models.Launch.LaunchModel.Root> Launches, List<ElonRich.API.Models.Rocket.RocketModel.Root> Rockets)
        {
            decimal total = 0;

            foreach (var launch in Launches)
            {
                foreach (var rocket in Rockets)
                {
                    if (launch.Rocket.RocketId == rocket.RocketId)
                    {
                        total += rocket.CostPerLaunch;
                    }
                }
            }
            return total;
        }
    }
}
