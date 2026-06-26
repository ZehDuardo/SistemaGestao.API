using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestao.API.Data;
using SistemaGestao.API.Models;

namespace SistemaGestao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcupacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcupacaoController(AppDbContext context)
        {
            _context = context;
        }

        // VAGAS OCUPADAS
        [HttpGet("ativas")]
        public async Task<IActionResult> GetAtivas()
        {
            var ocupacoes = await _context.Ocupacoes
                .Where(o => o.DataSaida == null)
                .Include(o => o.Veiculo)
                .Include(o => o.Cliente)
                .ToListAsync();
            return Ok(ocupacoes);
        }

        // REGISTRAR ENTRADA
        [HttpPost("entrada")]
        public async Task<IActionResult> Entrada([FromBody] EntradaDto dto)
        {
            var vagaOcupada = await _context.Ocupacoes
                .AnyAsync(o => o.NumeroVaga == dto.NumeroVaga && o.DataSaida == null);

            if (vagaOcupada)
                return BadRequest("Vaga já está ocupada.");

            var ocupacao = new Ocupacao
            {
                NumeroVaga = dto.NumeroVaga,
                VeiculoId = dto.VeiculoId,
                ClienteId = dto.ClienteId
            };

            _context.Ocupacoes.Add(ocupacao);
            await _context.SaveChangesAsync();
            return Ok(ocupacao);
        }

        // REGISTRAR SAÍDA
        [HttpPost("saida/{numeroVaga}")]
        public async Task<IActionResult> Saida(int numeroVaga)
        {
            var ocupacao = await _context.Ocupacoes
                .FirstOrDefaultAsync(o => o.NumeroVaga == numeroVaga && o.DataSaida == null);

            if (ocupacao == null)
                return NotFound("Vaga não está ocupada.");

            ocupacao.DataSaida = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(ocupacao);
        }

        // HISTÓRICO COMPLETO
        [HttpGet("historico")]
        public async Task<IActionResult> Historico()
        {
            var historico = await _context.Ocupacoes
                .Include(o => o.Veiculo)
                .Include(o => o.Cliente)
                .OrderByDescending(o => o.DataEntrada)
                .ToListAsync();
            return Ok(historico);
        }
    }

    public record EntradaDto(int NumeroVaga, int VeiculoId, int ClienteId);
}