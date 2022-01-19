using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SerwisOgloszen.Models;
using SerwisOgloszen.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerwisOgloszen.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public HomeController(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            var motorcycles = _motorcycleRepository.DownloadAllMotorcycles().OrderBy(m => m.Mark);

            var homeVM = new HomeVM()
            {
                Title = "Przeglad motocykli",
                Motorcycle = motorcycles.ToList()
            };

            return View(homeVM);
        }

        public IActionResult Szczegoly(int id)
        {
            var motorcycle = _motorcycleRepository.DownloadMotorcycleWithId(id);

            if (motorcycle == null)
                return NotFound();

            return View(motorcycle);

        }
    }
}
