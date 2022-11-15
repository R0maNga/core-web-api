using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Input.CupboardInput;

public class DeleteCupboard
{
    [Required] public Guid Id { get; set; }
}