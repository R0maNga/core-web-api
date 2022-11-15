namespace DAL.Entities;

public class Clothes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CupboardClothes> CupboardClothes { get; set; }
    public int DefaultQuantity { get; set; }
}