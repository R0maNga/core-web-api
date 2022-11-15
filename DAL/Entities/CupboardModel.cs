namespace DAL.Entities;

public class CupboardModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public List<Cupboard> Cupboards { get; set; }
}