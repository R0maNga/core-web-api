using System.ComponentModel.DataAnnotations;

namespace core_web_api.Models.Request.CupboardClothesRequest;

public class DeleteCupboardClothesRequest
{
    [Required] public Guid Id { get; set; }
}