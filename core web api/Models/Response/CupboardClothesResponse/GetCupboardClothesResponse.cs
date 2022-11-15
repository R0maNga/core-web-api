namespace core_web_api.Models.Response.CupboardClothesResponse;

public class GetCupboardClothesResponse
{
    public Guid Id { get; set; }
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
    public int Quantity { get; set; }
}