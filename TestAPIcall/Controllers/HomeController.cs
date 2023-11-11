using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Resources;
using TestAPIcall.Data;
using TestAPIcall.Models;

namespace TestAPIcall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicatonDbContext _context;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, ApplicatonDbContext context)
        {
            _logger = logger;
            this._hostEnvironment = hostEnvironment;
            _context = context;
        }

      
        [HttpGet]
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
        [HttpPost]
        public async Task<IActionResult> Index(string ResourceName)
        {
            List<Resources> ResourcesList = new List<Resources>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7093/api/Resource/"+ ResourceName))
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
        public IActionResult ImageUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}