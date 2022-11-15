namespace BLL.Models.Output.CLothesOutput;

public class GetCLothesOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? DefaultQuantity { get; set; }
}