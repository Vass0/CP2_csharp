using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;
using Prova.Api.Models;

namespace Prova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly AppDbContext _db;
    public ClienteController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get() =>
        await _db.Clientes.AsNoTracking().ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var item = await _db.Clientes.FindAsync(id);
        return item is null ? NotFound() : item;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente dto)
    {
        _db.Clientes.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Cliente dto)
    {
        if (id != dto.Id) return BadRequest();
        _db.Entry(dto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Clientes.FindAsync(id);
        if (item is null) return NotFound();
        _db.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}