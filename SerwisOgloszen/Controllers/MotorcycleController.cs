using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerwisOgloszen.Models;

namespace SerwisOgloszen.Controllers
{
    public class MotorcycleController : Controller
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private IHostingEnvironment _env;

        public MotorcycleController(IMotorcycleRepository motorcycleRepository, IHostingEnvironment env)
        {
            _motorcycleRepository = motorcycleRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_motorcycleRepository.DownloadAllMotorcycles());
        }

        public IActionResult Details(int id)
        {
            var motorcycle = _motorcycleRepository.DownloadMotorcycleWithId(id);
            if (motorcycle == null)
                return NotFound();

            return View(motorcycle);
        }

        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Motorcycle motorcycle)
        {
            if (ModelState.IsValid)
            {
                _motorcycleRepository.AddMotorcycle(motorcycle);
                return RedirectToAction(nameof(Index));
            }
            return View(motorcycle);
        }

        public IActionResult Edit(int id, string FileName)
        {
            var motorcycle = _motorcycleRepository.DownloadMotorcycleWithId(id);
            if (motorcycle == null)
                return NotFound();

            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            else
                ViewBag.ImgPath = motorcycle.Photo;

            return View(motorcycle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Motorcycle motorcycle)
        {
            if (ModelState.IsValid)
            {
                _motorcycleRepository.EditMotorcycle(motorcycle);
                return RedirectToAction(nameof(Index));
            }
            return View(motorcycle);
        }

        public IActionResult Delete(int id)
        {
            var motorcycle = _motorcycleRepository.DownloadMotorcycleWithId(id);
            if (motorcycle == null)
                return NotFound();

            return View(motorcycle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, string Photo)
        {
            var motorcycle = _motorcycleRepository.DownloadMotorcycleWithId(id);
            _motorcycleRepository.RemoveMotorcycle(motorcycle);

            //Usuwanie pliku
            if (Photo != null)
            {
                var webRoot = _env.WebRootPath;
                var filePath = Path.Combine(webRoot.ToString() + Photo);
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormCollection form)
        {
            var webRoot = _env.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

            if (form.Files[0].FileName.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }

            if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
                return RedirectToAction(nameof(Create), new { FileName = Convert.ToString(form.Files[0].FileName) });

            return RedirectToAction(nameof(Edit), new { FileName = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["Id"]) });
        }

    }
}
