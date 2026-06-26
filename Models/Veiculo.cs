namespace SistemaGestao.API.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}