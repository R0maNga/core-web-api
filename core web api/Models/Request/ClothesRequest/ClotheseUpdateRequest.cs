using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace core_web_api.Models.Request.ClothesRequest;

public class ClotheseUpdateRequest
{
    [BindRequired] public Guid Id { get; set; }

    [BindRequired] [MinLength(1)] public string Name { get; set; } = string.Empty;

    [BindRequired] public int DefaultQuantity { get; set; }
}