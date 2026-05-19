namespace PJATK_APBD_Cw7_s34434.DTOs;

public class ComponentManufacture
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime? FoundationDate { get; set; }

    public List<Component> Components { get; set; } = new List<Component>();
}