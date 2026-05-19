namespace PJATK_APBD_Cw7_s34434.DTOs;

public class PCComponent
{
    public int PCId { get; set; }
    public PC PC { get; set; } = null!;

    public string ComponentCode { get; set; } = null!;
    public Component Component { get; set; } = null!;

    public int Amount { get; set; }
}