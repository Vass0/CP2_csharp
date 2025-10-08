

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Api.Models
{
    [Table("CLIENTE")]   // 👈 força usar a tabela singular
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }
    }
}