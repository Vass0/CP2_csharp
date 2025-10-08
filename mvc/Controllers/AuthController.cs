using Microsoft.AspNetCore.Mvc;
using Prova.Mvc.Services;

namespace Prova.Mvc.Controllers;

public record LoginRequest(string Login, string Senha);

public class AuthController : Controller
{
    private readonly ApiClient _api;
    public AuthController(ApiClient api) => _api = api;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(LoginRequest req)
    {
        var resp = await _api.PostAsync("api/login", req);
        if (resp.IsSuccessStatusCode) return RedirectToAction("Index", "Home");
        ViewBag.Error = "Login inválido";
        return View(req);
    }
}
