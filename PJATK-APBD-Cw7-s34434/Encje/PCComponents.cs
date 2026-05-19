using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s34434.DTOs;

[Table("PCComponents")]
public class PCComponents
{
    [Required]
    public int PCId { get; set; }
    [MaxLength(10)]
    [Required]
    public string ComponentCode { get; set; }
    public string Ammount { get; set; }
}