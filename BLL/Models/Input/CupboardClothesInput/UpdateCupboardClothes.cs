namespace BLL.Models.Input.CupboardClothesInput;

public class UpdateCupboardClothes
{
    public Guid Id { get; set; }
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
    public int Quantity { get; set; }
}