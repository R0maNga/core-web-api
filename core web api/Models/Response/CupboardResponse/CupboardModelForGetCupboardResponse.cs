namespace core_web_api.Models.Response.CupboardResponse;

public class CupboardModelForGetCupboardResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Year { get; set; }
}