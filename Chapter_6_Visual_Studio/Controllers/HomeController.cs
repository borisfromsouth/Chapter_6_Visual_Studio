using Chapter_6_Visual_Studio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter_6_Visual_Studio.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository = SimpleRepository.SharedRepository;

        public IActionResult Index() => View(Repository.Products/*.Where(p => p?.Price < 50)*/);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product()); // при вызове на главной asp-action="AddProduct"

        [HttpPost]
        public IActionResult AddProduct(Product p)  // в AddProduct есть поле-кнопка submit, оно по сути является аналогом return, поэтому после нажатия форма возвращается для дальнейшей обработки
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}
