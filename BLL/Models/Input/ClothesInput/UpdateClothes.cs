namespace BLL.Models.Input.ClothesInput;

public class UpdateClothes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultQuantity { get; set; }
}