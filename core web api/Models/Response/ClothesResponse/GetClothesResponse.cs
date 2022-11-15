namespace core_web_api.Models.Response.ClothesResponse;

public class GetClothesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? DefaultQuantity { get; set; }
}