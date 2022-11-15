namespace BLL.Models.Output.CupboardOutput;

public class CupboardModelForGetCupboardOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Year { get; set; }
}