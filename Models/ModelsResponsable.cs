using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("responsables")]
public class Responsable
{
    [Key]
    [Column("Id_Responsable")]
    public int Id_Responsable { get; set; }

    [Required]
    [Column("Nombre_Resp")]
    [StringLength(30)]
    public string Nombre_Resp { get; set; }

    [Required]
    [Column("Mail_Resp")]
    [StringLength(25)]
    public string Mail_Resp { get; set; }

    [Required]
    [Column("Telefono")]
    [StringLength(8)]
    public string Telefono { get; set; }
 }
