using SistemaGestao.API.Models;

namespace SistemaGestao.API.Models
{
    public class Ocupacao
    {
        public int Id { get; set; }
        public int NumeroVaga { get; set; }
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        public DateTime? DataSaida { get; set; }

        public Veiculo? Veiculo { get; set; }
        public Cliente? Cliente { get; set; }
    }
}