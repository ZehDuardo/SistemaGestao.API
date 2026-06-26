using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestao.API.Data;
using SistemaGestao.API.Models;

namespace SistemaGestao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return Ok(veiculos);
        }

        // CADASTRAR
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] VeiculoDto dto)
        {
            var veiculo = new Veiculo
            {
                Tipo = dto.Tipo,
                Placa = dto.Placa.ToUpper(),
                Modelo = dto.Modelo,
                Cor = dto.Cor
            };

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return Ok(veiculo);
        }

        // EXCLUIR
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) return NotFound();
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veículo excluído.");
        }
    }

    public record VeiculoDto(string Tipo, string Placa, string Modelo, string Cor);
}