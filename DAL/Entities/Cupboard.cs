namespace DAL.Entities;

public class Cupboard
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; }
    public Guid ModelId { get; set; }
    public List<CupboardClothes> CupboardClothes { get; set; }
    public CupboardModel CupboardModel { get; set; }
}