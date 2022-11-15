namespace BLL.Models.Output.CupboardModelOutput;

public class GetCupboardModelOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Year { get; set; }
}