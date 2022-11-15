using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace core_web_api.Controllers;

[Route("api/procedure")]
[ApiController]
public class StoredProcedureController : Controller
{
    private readonly ICupboardClothesService _icupboardClothes;
    private readonly ILogger<StoredProcedureController> _logger;
    private readonly IMapper _mapper;

    public StoredProcedureController(ICupboardClothesService icupboardClothes,
        ILogger<StoredProcedureController> logger, IMapper mapper)
    {
        _icupboardClothes = icupboardClothes;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ExecuteProcedure(CancellationToken token)
    {
        try
        {
            var data = _icupboardClothes.ExecuteProcedure();


            foreach (var item in data.ToList())
            {
                var _cupboardClothes = await _icupboardClothes.GetByIdAsync(item.Id, token);

                if (_cupboardClothes is null) continue;
                _cupboardClothes.Quantity = item.DefaultQuantity;

                await _icupboardClothes.UpdateAsync(_mapper.Map<UpdateCupboardClothes>(_cupboardClothes), token);
            }

            return Ok("Clothes replaced");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}