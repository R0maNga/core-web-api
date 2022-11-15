using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Services.Interfaces;
using core_web_api.Models.Request.ClothesRequest;
using core_web_api.Models.Response.ClothesResponse;
using Microsoft.AspNetCore.Mvc;

namespace core_web_api.Controllers;

[Route("api/clothes")]
[ApiController]
public class ClothesController : ControllerBase
{
    private readonly IClothesService _clothesService;
    private readonly ILogger<ClothesController> _logger;
    private readonly IMapper _mapper;


    public ClothesController(IClothesService clothesService, IMapper mapper, ILogger<ClothesController> logger)
    {
        _clothesService = clothesService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        try
        {
            var clothes = _mapper.Map<IEnumerable<GetClothesResponse>>(await _clothesService.GetAsync(token));


            return Ok(clothes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        try
        {
            var clothes = await _clothesService.GetByIdAsync(id, token);

            return Ok(clothes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        try
        {
            var data = await _clothesService.GetByIdAsync(id, token);
            var mappedData = _mapper.Map<DeleteClothes>(data);
            await _clothesService.DeleteAsync(mappedData, token);
            return Ok("Clothes deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClothesCreateRequest clothes, CancellationToken token)
    {
        try
        {
            var mappedData = _mapper.Map<CreateClothes>(clothes);
            await _clothesService.CreateAsync(mappedData, token);
            return Ok("Clothes created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ClotheseUpdateRequest clothes, CancellationToken token)
    {
        try
        {
            var dbClothes = await _clothesService.GetByIdAsync(clothes.Id, token);
            if (dbClothes == null)
            {
                _logger.LogError("Bad clothes id");
                return BadRequest();
            }

            await _clothesService.UpdateAsync(_mapper.Map<UpdateClothes>(clothes), token);
            return Ok("Clothes updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}