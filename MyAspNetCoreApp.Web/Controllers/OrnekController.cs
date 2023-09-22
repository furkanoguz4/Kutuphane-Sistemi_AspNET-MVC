using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product
    {
        public int sirası { get; set; }
        public string name { get; set; }
    }
    public class OrnekController : Controller
    {
        //public IActionResult Index()
        //{
        //    ViewBag.name = "selma";
        //    ViewData["yas"] = 12;

        //    var productList = new List<Product>()
        //    {
        //        new (){ sirası = 12, name = "Türkiye" },
        //        new (){ sirası=2,name = "Sırbistan"} 
        //    };

        //    return View(productList);
        //}
        //public IActionResult Index2()  // index2 ile index sayfasına yönlendirme
        //{
        //    return RedirectToAction("Index","Ornek");
        //}

        //Dönüş tiplerimiz view olmak zorunda değil 
        //public IActionResult ContentResult()
        //{
        //    return Content("string ifadeler"); //  /ornek/contentresult eklendiğinde çıkar
        //}

        //public IActionResult JsonResult()
        //{
        //    return Json(new { id=1 , name = " furkan " , surname = " oguz "   });
        //}

        //public IActionResult EmptyResult()
        //{
        //    return new EmptyResult(); // result da yazılıyor .
        //}

        
    }
}
