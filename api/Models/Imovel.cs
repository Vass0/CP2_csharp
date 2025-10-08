namespace Prova.Api.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Residencial"; // Residencial/Comercial
        public decimal Valor { get; set; }
        public bool Ativo { get; set; } = true;
    }
}