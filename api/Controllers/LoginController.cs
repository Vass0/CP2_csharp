using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;
using Prova.Api.Models;
using System.Security.Cryptography;
using System.Text;

namespace Prova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _db;
    public LoginController(AppDbContext db) => _db = db;

    public static string Hash(string input)
    {
        using var sha = SHA256.Create();
        return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }

    [HttpPost]
    public async Task<ActionResult<object>> Login([FromBody] LoginRequest req)
    {
        var hash = Hash(req.Senha);
        var user = await _db.Usuarios.FirstOrDefaultAsync(u => u.Login == req.Login && u.SenhaHash == hash);
        if (user is null) return Unauthorized();
        return new { message = "ok", user = new { user.Login, user.Role } };
    }

    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        if (!await _db.Usuarios.AnyAsync())
        {
            _db.Usuarios.Add(new Usuario { Login = "admin", SenhaHash = Hash("admin123"), Role = "Admin" });
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}

public record LoginRequest(string Login, string Senha);
