using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class SinifController : Controller
    {
        HazirlikDbContext veritabani = new HazirlikDbContext();
        public IActionResult Index()
        {
            return View(veritabani.Siniflar.ToList());
        }
        public IActionResult Guncelle(int id)
        {
            Sinif sinif = veritabani.Siniflar.Find(id);
            return View(sinif);
        }
        [HttpPost]
        public IActionResult Guncelle(Sinif sinif)
        {
            veritabani.Entry<Sinif>(sinif).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            veritabani.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int? id)
        {
            Sinif sinif = veritabani.Siniflar.Find(id);
            veritabani.Siniflar.Remove(sinif);
            veritabani.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Ekle() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Sinif sinif)
        {
            veritabani.Siniflar.Add(sinif);
            veritabani.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
