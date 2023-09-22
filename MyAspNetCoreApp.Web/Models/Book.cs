namespace MyAspNetCoreApp.Web.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key
        public string Adi { get; set; }
        public string Yazar { get; set; }
        //public DateTime YayinTarihi { get; set; }
        public string Kategori { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }


    }
}
