using SirvalApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("asignaciones")]
public class Asignacion
{
    [Key]
    [Column("Id_Asignacion")]
    public int Id_Asignacion { get; set; }

    [Required]
    [Column("Id_Alerta")]
    public int Id_Alerta { get; set; }

    [Required]
    [Column("Id_Responsable")]
    public int Id_Responsable { get; set; }

    [Required]
    [Column("Fecha_Asig")]
    public DateTime Fecha_Asig { get; set; }

    [Required]
    [Column("Estado_Asig")]
    [StringLength(10)]
    public string Estado_Asig { get; set; }

    [Required]
    [Column("Observaciones_Asig")]
    [StringLength(100)]
    public string Observaciones_Asig { get; set; }

    [Required]
    [Column("FechaResol_Asig")]
    public DateTime FechaResol_Asig { get; set; }
}
