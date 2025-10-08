using Microsoft.AspNetCore.Mvc;

namespace Prova.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
