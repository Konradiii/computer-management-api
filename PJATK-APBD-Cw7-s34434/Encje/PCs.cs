using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s34434.DTOs;

[Table("PCs")]
public class PCs
{
    [Key]
    [Required]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(5)]
    public float Weight { get; set; }
    public int Warrianty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<PCComponents> PCComponents { get; set; }

}