namespace BLL.Models.Output.CupboardOutput;

public class GetCupboardOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? OwnerName { get; set; }
    public Guid ModelId { get; set; }
    public CupboardModelForGetCupboardOutput CupboardModel { get; set; }
}