using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Games.Model
{
    public class Produto : Auditable
    {
        [Key] // Primari Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity (1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Foto { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public decimal Avaliacao { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
