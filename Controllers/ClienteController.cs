using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestao.API.Data;
using SistemaGestao.API.Models;

namespace SistemaGestao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // CADASTRAR
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ClienteDto dto)
        {
            if (await _context.Clientes.AnyAsync(c => c.CPF == dto.CPF))
                return BadRequest("CPF já cadastrado.");

            var cliente = new Cliente
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                Telefone = dto.Telefone,
                Email = dto.Email
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        // EXCLUIR
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente excluído.");
        }
    }

    public record ClienteDto(string Nome, string CPF, string Telefone, string Email);
}