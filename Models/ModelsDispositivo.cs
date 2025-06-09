using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SirvalApi.Models
{
    [Table("dispositivos")]
    public class Dispositivo
    {
        [Key]
        [Column("Id_Dispositivo")]
        public int Id_Dispositivo { get; set; }

        [Required]
        [Column("Tipo_Disp")]
        [StringLength(25)]
        public string Tipo_Disp { get; set; }

        [Required]
        [Column("Nombre_Disp")]
        [StringLength(15)]
        public string Nombre_Disp { get; set; }

        [Required]
        [Column("Ubicacion_Disp")]
        [StringLength(25)]
        public string Ubicacion_Disp { get; set; }

        [Required]
        [Column("IP")]
        [StringLength(15)]
        public string IP { get; set; }
    }
}