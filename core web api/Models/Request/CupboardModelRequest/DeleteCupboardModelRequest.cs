using System.ComponentModel.DataAnnotations;

namespace core_web_api.Models.Request.CupboardModelRequest;

public class DeleteCupboardModelRequest
{
    [Required] public Guid Id { get; set; }
}