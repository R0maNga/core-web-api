using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Input.ClothesInput;

public class DeleteClothes
{
    [Required] public Guid Id { get; set; }
}