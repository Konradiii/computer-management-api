namespace PJATK_APBD_Cw7_s34434.DTOs;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<Component> Components { get; set; } = new List<Component>();
}