namespace BLL.Models.Output.ProcedureOutput;

public class ProcedureOutput
{
    public int DefaultQuantity { get; set; }
    public Guid Id { get; set; }
    public Guid CupboardId { get; set; }
    public Guid ClothesId { get; set; }
}