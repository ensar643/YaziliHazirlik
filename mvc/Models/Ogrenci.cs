namespace mvc.Models
{
    public class Ogrenci
    {
        public string OgrenciAdi { get; set; }
        public int OgrenciId { get; set; }
        public string OgrenciSoyadi { get; set; }

        public Sinif? Sinif { get; set; }
        public int? SinifId { get; set; }
    }
}
