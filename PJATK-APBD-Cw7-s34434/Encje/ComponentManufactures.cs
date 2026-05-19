using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace PJATK_APBD_Cw7_s34434.DTOs;

[Table("ComponentManufactures")]
public class ComponentManufactures
{
    [Required]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(300)]
    public string FullName { get; set; }
    [Column(TypeName = "date")]
    public DateTime FoundationDate { get; set; }
    public List<Components> Components { get; set; }
}