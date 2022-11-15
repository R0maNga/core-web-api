namespace BLL.Models.Input.CupboardModelnput;

public class UpdateCupboardModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
}