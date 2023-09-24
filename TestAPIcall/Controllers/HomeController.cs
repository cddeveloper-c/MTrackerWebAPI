using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TestAPIcall.Models;

namespace TestAPIcall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
            
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            List<Resources> ResourcesList = new List<Resources>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Resource/api/Resource/GetResource"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ResourcesList = JsonConvert.DeserializeObject<List<Resources>>(apiResponse);
                }
            }
            return View(ResourcesList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}