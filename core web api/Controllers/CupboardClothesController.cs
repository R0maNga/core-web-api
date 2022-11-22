using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Models.Output.CupboardClothesOutput;
using BLL.Services.Interfaces;
using core_web_api.Models.Request.CupboardClothesRequest;
using Microsoft.AspNetCore.Mvc;

namespace core_web_api.Controllers;

[Route("api/cupboard-clothes")]
[ApiController]
public class CupboardClothesController : ControllerBase
{
    private readonly ICupboardClothesService _icupboardClothes;
    private readonly ILogger<CupboardClothesController> _logger;
    private readonly IMapper _mapper;


    public CupboardClothesController(ICupboardClothesService icupboardClothes,
        ILogger<CupboardClothesController> logger, IMapper mapper)
    {
        _icupboardClothes = icupboardClothes;
        _logger = logger;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateCupboardClothesRequest cupboardClothes, CancellationToken token)
    {
        try
        {
            var mappedData = _mapper.Map<CreateCupboardClothes>(cupboardClothes);

            await _icupboardClothes.CreateAsync(mappedData, token);
            return Ok("CupboardClothes made");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        try
        {
            var cupboardClothes =
                _mapper.Map<IEnumerable<GetCupboardClothesOutput>>(await _icupboardClothes.GetAsync(token));


            return Ok(cupboardClothes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteCupboardClothesRequest cupboardClothes, CancellationToken token)
    {
        try
        {
            var mappedData = _mapper.Map<DeleteCupboardClothes>(cupboardClothes);

            await _icupboardClothes.DeleteAsync(mappedData, token);
            return Ok("CupboardClothes deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}