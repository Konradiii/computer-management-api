using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s34434.DTOs;

[Table("Components")]
public class Components
{
    [Key]
    [MaxLength(10)]
    [Required]
    public string Code { get; set; }
    [MaxLength(300)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int ComponentManufacturesId { get; set; }
    public int COmponentTypeId { get; set; }
    public List<PCComponents> PCComponents { get; set; }
}