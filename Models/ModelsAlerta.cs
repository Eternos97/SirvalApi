using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SirvalApi.Models
{
    [Table("registro_alertas")]
    public class Alerta
    {
        [Key]
        [Column("Id_Alerta")]
        public int Id_Alerta { get; set; }

        [Required]
        [Column("Id_TipoAlerta")]
        public int Id_TipoAlerta { get; set; }

        [Required]
        [Column("Id_Dispositivo")]
        public int Id_Dispositivo { get; set; }

        [Required]
        [Column("Severidad")]
        [StringLength(10)]
        public string Severidad { get; set; }

        [Required]
        [Column("Detalle_Alerta")]
        [StringLength(50)]
        public string Detalle_Alerta { get; set; }

        [Required]
        [Column("Fecha_Alerta")]
        public DateTime Fecha_Alerta { get; set; }
    }
}