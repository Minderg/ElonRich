using ElonRich.API.Api;
using ElonRich.API.Models.Rocket;
using ElonRich.Logic.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;
using static ElonRich.API.Models.Launch.LaunchModel;

namespace ElonRich.Ui.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PriceManager priceManager;
        public List<ElonRich.API.Models.Launch.LaunchModel.Root> Launches { get; set; } = new List<ElonRich.API.Models.Launch.LaunchModel.Root>();
        public List<ElonRich.API.Models.Rocket.RocketModel.Root> Rockets { get; set; } = new List<ElonRich.API.Models.Rocket.RocketModel.Root>();
        public decimal Price { get; set; }

        public IndexModel(PriceManager priceManager)
        {
            this.priceManager = priceManager;
        }

        public async Task OnGet()
        {
            Rockets = await new ApiCaller().GetAllRockets();

        }

        public async Task<IActionResult> OnPost()
        {
            Launches = await new ApiCaller().GetAllLaunches();
            Rockets = await new ApiCaller().GetAllRockets();
            Price = await priceManager.CalculateTotalPrice(Launches, Rockets);

            return Page();
        }
    }
}