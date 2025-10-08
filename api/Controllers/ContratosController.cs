using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;
using Prova.Api.Models;

namespace Prova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratosController : ControllerBase
{
    private readonly AppDbContext _db;
    public ContratosController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<ActionResult<Contrato>> Create(Contrato dto)
    {
        // regra: DataFim > DataInicio
        if (dto.DataFim <= dto.DataInicio) return BadRequest("Data fim deve ser maior que início.");
        // Ao criar, marca Ativo
        dto.Ativo = true;
        _db.Contratos.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contrato>> GetById(int id)
    {
        var c = await _db.Contratos.Include(x => x.Cliente).Include(x => x.Imovel)
            .FirstOrDefaultAsync(x => x.Id == id);
        return c is null ? NotFound() : c;
    }

    [HttpPost("{id:int}/encerrar")]
    public async Task<IActionResult> Encerrar(int id)
    {
        var c = await _db.Contratos.FindAsync(id);
        if (c is null) return NotFound();
        c.Ativo = false;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}