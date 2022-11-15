namespace core_web_api.Models.Request.CupboardModelRequest;

public class UpdateCupboardModelRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
}