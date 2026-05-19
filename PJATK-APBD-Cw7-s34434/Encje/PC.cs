namespace PJATK_APBD_Cw7_s34434.DTOs;

public class PC
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public string? Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public List<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}