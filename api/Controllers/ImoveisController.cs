using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;
using Prova.Api.Models;

namespace Prova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImoveisController : ControllerBase
{
    private readonly AppDbContext _db;
    public ImoveisController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Imovel>>> Get() =>
        await _db.Imoveis.AsNoTracking().ToListAsync();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Imovel dto)
    {
        if (id != dto.Id) return BadRequest();
        // Regra: bloquear alterações se houver contrato ativo
        var possuiContratoAtivo = await _db.Contratos.AnyAsync(c => c.ImovelId == id && c.Ativo);
        if (possuiContratoAtivo) return BadRequest("Imóvel com contrato ativo não pode ser alterado.");
        _db.Entry(dto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Imovel>> Create(Imovel dto)
    {
        _db.Imoveis.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }
}