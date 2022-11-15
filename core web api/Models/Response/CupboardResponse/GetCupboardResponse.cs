namespace core_web_api.Models.Response.CupboardResponse;

public class GetCupboardResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? OwnerName { get; set; }
    public Guid ModelId { get; set; }
    public CupboardModelForGetCupboardResponse CupboardModel { get; set; }
}