using System.ComponentModel.DataAnnotations;

namespace core_web_api.Models.Request.CupboardClothesRequest;

public class CreateCupboardClothesRequest
{
    [Required] public Guid CupboardId { get; set; }

    [Required] public Guid ClothesId { get; set; }

    [Required] public int Quantity { get; set; }
}