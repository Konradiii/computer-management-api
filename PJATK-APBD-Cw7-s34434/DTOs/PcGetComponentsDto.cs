namespace PJATK_APBD_Cw7_s34434.DTOs;

public class PcGetComponentsDto
{
    public int PCId { get; set; }
    public List<ComponentItemDto> Components { get; set; } = new();
}

public class ComponentItemDto
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
}