using SirvalApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirvalApi.Models
{
    [Table("tipos_alerta")]
    public class TipoAlerta
    {
        [Key]
        [Column("Id_TipoAlerta")]
        public int Id_TipoAlerta { get; set; }

        [Required]
        [Column("Descripcion_TipoAlerta")]
        [StringLength(25)]
        public string Descripcion_TipoAlerta { get; set; }
    }
}