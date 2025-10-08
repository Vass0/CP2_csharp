using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;
using Prova.Api.Models;

namespace Prova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProdutosController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> Get() =>
        await _db.Produtos.AsNoTracking().ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Produto>> Create(Produto dto)
    {
        if (dto.Quantidade < 0) return BadRequest("Quantidade não pode ser negativa.");
        _db.Produtos.Add(dto);
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return BadRequest("SKU já existente ou erro de banco.");
        }
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> GetById(int id)
    {
        var item = await _db.Produtos.FindAsync(id);
        return item is null ? NotFound() : item;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Produto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (dto.Quantidade < 0) return BadRequest("Estoque não pode ficar negativo.");
        _db.Entry(dto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Produtos.FindAsync(id);
        if (item is null) return NotFound();
        _db.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}