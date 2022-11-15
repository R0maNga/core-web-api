using System.ComponentModel.DataAnnotations;

namespace core_web_api.Models.Request.CupboardRequest;

public class CreateCupboardRequest
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string OwnerName { get; set; }

    [Required] public Guid ModelId { get; set; }
}