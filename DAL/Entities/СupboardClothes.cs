namespace DAL.Entities;

public class CupboardClothes
{
    public Guid Id { get; set; }
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
    public Clothes Clothes { get; set; }
    public Cupboard Cupboard { get; set; }
    public int Quantity { get; set; }
}