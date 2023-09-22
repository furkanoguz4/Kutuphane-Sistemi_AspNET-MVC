using System.Drawing;

namespace MyAspNetCoreApp.Web.Models
{
    public class BookRepository
    {
        private static List<Book> _books = new List<Book>()
        {

                //new () { KitapID=1,Adi="Kitap1", Yazar = "Orhan Pamuk" , Kategori="Roman" ,Ozet="adkjbsada" ,SayfaSayisi=450 },
                //  new () { KitapID=2,Adi="Kitap2", Yazar = "Orhan Pamuk2" , Kategori="Roman" ,Ozet="adkjbsada" ,SayfaSayisi=550 },
                //new () { KitapID=3,Adi="Kitap3", Yazar = "Orhan Pamuk3" , Kategori="Roman" ,Ozet="adkjbsada" ,SayfaSayisi=750 }
        };
        public List<Book> GetAll()
        {
            return _books;
        }

        public void Add(Book newBook)
        {
            _books.Add(newBook);
        }
        public void Remove(int id)
        {
            var hasBook = _books.FirstOrDefault(x => x.Id == id);
            if (hasBook == null)
            {
                throw new Exception("Öyle bi word yok tatlım");
            }
            _books.Remove(hasBook);
        }
        public void Update(Book guncellenecekKitap)
        {
            // KitapID'ye göre güncellenmek istenen kitabı veritabanından alın
            var hasBook = _books.FirstOrDefault(x => x.Id == guncellenecekKitap.Id);

            if (hasBook == null)
            {
                throw new Exception("Öyle bi word yok tatlım");

            }
            hasBook.Adi=guncellenecekKitap.Adi;
            hasBook.Yazar=guncellenecekKitap.Yazar;
            hasBook.Kategori=guncellenecekKitap.Kategori;
            hasBook.Ozet = guncellenecekKitap.Ozet;
            hasBook.SayfaSayisi = guncellenecekKitap.SayfaSayisi;

            var index = _books.FindIndex(x=>x.Id==guncellenecekKitap.Id);
            _books[index] = hasBook;

        }



    }
}
