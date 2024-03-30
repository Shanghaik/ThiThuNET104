using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThiThu.Models;

namespace ThiThu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext context = new AppDbContext();
        public HomeController()
        {

        }


        public IActionResult Index()
        {
            var data = context.Sinhviens.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sinhvien sv)
        {
            sv.Id = Guid.NewGuid();
            context.Sinhviens.Add(sv);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");   
        }
        public IActionResult Delete(Guid id)
        {
            var data = context.Sinhviens.Find(id);
            context.Sinhviens.Remove(data); 
            context.SaveChanges(); 
            return RedirectToAction("Index", "Home"); return View(data);
        }
        public IActionResult Details(Guid id)
        {
            var data = context.Sinhviens.Find(id);
            return View(data);
        }
        public IActionResult Edit(Guid id)
        {
            var data = context.Sinhviens.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Sinhvien sv)
        {
            var update = context.Sinhviens.Find(sv.Id);
            update.Tuoi = sv.Tuoi;
            update.Name =sv.Name;
            context.Sinhviens.Update(update);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}