namespace PJATK_APBD_Cw7_s34434.DTOs;

public class Component
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int ComponentManufacturesId { get; set; }
    public ComponentManufacture ComponentManufacture { get; set; } = null!;

    public int ComponentTypeId { get; set; }
    public ComponentType ComponentType { get; set; } = null!;

    public List<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}