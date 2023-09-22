using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;


namespace MyAspNetCoreApp.Web.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext _context;
        private readonly BookRepository _bookRepository;

        public BooksController(AppDbContext context)
        {

            _bookRepository = new BookRepository();
            _context = context;
        }


        public IActionResult Index()
        {
            var books = _context.Books.ToList(); // ekrana göstermiyorsa düzenleme yap context olarak çevir 
            return View(books);
        }
        public IActionResult Remove(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            TempData["Status"] = "Kişi Başarıyla Silindi !";
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }

        //1. Yöntem
        //public IActionResult SaveData()
        //{
        //    var adi = HttpContext.Request.Form["Adi"].ToString();
        //    var yazar  = HttpContext.Request.Form["Yazar"].ToString();
        //    var kategori  = HttpContext.Request.Form["Kategori"].ToString();
        //    var ozet  = HttpContext.Request.Form["Özet"].ToString();
        //    var sayfasayisi  = int.Parse(HttpContext.Request.Form["SayfaSayisi"].ToString());

        //    Book newBook = new Book() { Adi=adi , Yazar = yazar ,Kategori=kategori ,Ozet = ozet , SayfaSayisi = sayfasayisi};
        //    _context.Books.Add(newBook);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // 2. yöntem ( .netin avantajları )

        [HttpPost]
        //public IActionResult Add(string Adi , string Yazar ,string Kategori ,string Özet , int SayfaSayisi ) // girdilerin form nameinde verdiğimiz isimlerin aynısını burada parametre olarak verirsek .net bunu algılıyor otomatik çekiyor
        //{

        //    Book newBook = new Book() { Adi = Adi, Yazar = Yazar, Kategori = Kategori, Ozet = Özet, SayfaSayisi = SayfaSayisi };
        //    _context.Books.Add(newBook);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // 3. Yöntem Tip Güvenli Olan ( yöntemler sırayla git gide best practice olmakta )
        public IActionResult Add(Book newBook) {
            // bu yöntemi yapınca mecburen Add.cshtml dosyamda da asp-for kullanacağım üsttekinin cshtml dekini yoruma alırım 
            
            _context.Books.Add(newBook);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi .";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book updateBook)
        {
            _context.Books.Update(updateBook);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi .";
            return RedirectToAction("index");
        }
        public IActionResult Search(string aramaKelimesi)
        {
            var urunler = _context.Books.Where(u => u.Adi.Contains(aramaKelimesi) || u.Yazar.Contains(aramaKelimesi)).ToList();
            return View("index",urunler);
        }
        public IActionResult Go()
        {
            return RedirectToAction("index");
        }
    }
}
