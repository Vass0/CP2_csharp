namespace Prova.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}