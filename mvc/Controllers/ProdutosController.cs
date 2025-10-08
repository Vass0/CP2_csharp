using Microsoft.AspNetCore.Mvc;
using Prova.Mvc.Services;

namespace Prova.Mvc.Controllers;

public record Produto(int Id, string Nome, string SKU, int Quantidade, decimal Preco);

public class ProdutosController : Controller
{
    private readonly ApiClient _api;
    public ProdutosController(ApiClient api) => _api = api;

    public async Task<IActionResult> Index()
    {
        var data = await _api.GetAsync<List<Produto>>("api/produtos");
        return View(data ?? new List<Produto>());
    }
}
