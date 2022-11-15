namespace BLL.Models.Output.CupboardClothesOutput;

public class GetCupboardClothesOutput
{
    public Guid Id { get; set; }
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
    public int Quantity { get; set; }
}