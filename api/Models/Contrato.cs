using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Api.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ImovelId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; } = true;

        public Cliente? Cliente { get; set; }
        public Imovel? Imovel { get; set; }
    }
}