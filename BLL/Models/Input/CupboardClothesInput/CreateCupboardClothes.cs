namespace BLL.Models.Input.CupboardClothesInput;

public class CreateCupboardClothes
{
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
    public int Quantity { get; set; }
}