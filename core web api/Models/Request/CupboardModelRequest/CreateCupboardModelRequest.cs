using System.ComponentModel.DataAnnotations;

namespace core_web_api.Models.Request.CupboardModelRequest;

public class CreateCupboardModelRequest
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public int Year { get; set; }
}