namespace BLL.Models.Input.CupboardInput;

public class CreateCupboard
{
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; }
    public Guid ModelId { get; set; }
}