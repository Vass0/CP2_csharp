using Microsoft.AspNetCore.Mvc;
using Prova.Mvc.Services;
using System.Text.Json;

namespace Prova.Mvc.Controllers;

public record Cliente(int Id, string Nome, string Email, string Telefone);

public class ClientesController : Controller
{
    private readonly ApiClient _api;
    public ClientesController(ApiClient api) => _api = api;

    public async Task<IActionResult> Index()
    {
        var data = await _api.GetAsync<List<Cliente>>("api/clientes");
        return View(data ?? new List<Cliente>());
    }
}
