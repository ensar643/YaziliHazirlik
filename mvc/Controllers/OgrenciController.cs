using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Models;

namespace mvc.Controllers
{
    public class OgrenciController : Controller
    {
        HazirlikDbContext veritabani = new HazirlikDbContext();
        public IActionResult Index()
        {
            var liste = from ogrenci in veritabani.Ogrenciler
                        join Sinif in veritabani.Siniflar on ogrenci.SinifId
                        equals Sinif.SinifId
                        select new OgrenciSinifModel
                        {
                            OgrenciId = ogrenci.OgrenciId,
                            OgrenciAdi = ogrenci.OgrenciAdi,
                            OgrenciSoyadi = ogrenci.OgrenciSoyadi,
                            SinifAdi = Sinif.SinifAdi,
                            SinifKodu = Sinif.SinifKodu,

                        };
            return View(liste.ToList());
        }
        public IActionResult Guncelle(int id)
        {
            var sorgu = veritabani.Siniflar.ToList();
            ViewBag.siniflistesi = new SelectList(sorgu, "SinifId","SinifAdi");
            var ogrenci = veritabani.Ogrenciler.Find(id);
            return View(ogrenci);
        }
        [HttpPost]
        public IActionResult Guncelle(Ogrenci ogrenci)
        {
            veritabani.Entry<Ogrenci>(ogrenci).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            veritabani.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int? id)
        {
            Ogrenci ogrenci = veritabani.Ogrenciler.Find(id);
            veritabani.Ogrenciler.Remove(ogrenci);
            veritabani.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Ekle()
        {
            var SinifListesi = veritabani.Siniflar.ToList();
            ViewBag.SinifListesi = new SelectList(SinifListesi, "SinifId", "SinifAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Ogrenci ogrenci)
        {
            var siniflistesi = veritabani.Siniflar.ToList();
            ViewBag.siniflistesi = new SelectList(siniflistesi, "SinifId", "SinifAdi");
            ogrenci.SinifId = 2002;
            veritabani.Ogrenciler.Add(ogrenci);
            veritabani.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
