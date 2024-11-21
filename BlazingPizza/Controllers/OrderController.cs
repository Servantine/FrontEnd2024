using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
