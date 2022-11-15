namespace BLL.Models.Input.ClothesInput;

public class CreateClothes
{
    public string Name { get; set; } = string.Empty;
    public int DefaultQuantity { get; set; }
}