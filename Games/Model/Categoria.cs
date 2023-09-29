using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Model
{
    public class Categoria
    {
        [Key] // Primari Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity (1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Genero { get; set; } = string.Empty;

        [InverseProperty("Categoria")]
        public virtual ICollection<Produto>? Produto { get; set; }
    }
}
