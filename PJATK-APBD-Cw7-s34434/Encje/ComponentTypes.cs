using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s34434.DTOs;

[Table("ComponentTypes")]
public class ComponentTypes
{
    [Required]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation  { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    public List<Components> Components { get; set; }

}