using AutoMapper;
using BLL.Models.Input.CupboardInput;
using BLL.Services.Interfaces;
using core_web_api.Models.Request.CupboardRequest;
using core_web_api.Models.Response.CupboardResponse;
using Microsoft.AspNetCore.Mvc;

namespace core_web_api.Controllers;

[Route("api/cupboard")]
[ApiController]
public class CupboardController : Controller
{
    private readonly ICupboardService _cupboardService;


    private readonly ILogger<CupboardController> _logger;
    private readonly IMapper _mapper;


    public CupboardController(ILogger<CupboardController> logger, ICupboardService cupboardService, IMapper mapper)
    {
        _logger = logger;
        _cupboardService = cupboardService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCupboardRequest cupboard, CancellationToken token)
    {
        try
        {
            var mappedData = _mapper.Map<CreateCupboard>(cupboard);
            await _cupboardService.CreateAsync(mappedData, token);
            return Ok("Cupboard created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCupboardRequest cupboard, CancellationToken token)
    {
        try
        {
            var dbCupboard = await _cupboardService.GetByIdAsync(cupboard.Id, token);
            if (dbCupboard == null)
            {
                _logger.LogError("Bad event id");
                return BadRequest();
            }

            await _cupboardService.UpdateAsync(_mapper.Map<UpdateCupboard>(cupboard), token);
            return Ok("Clothes updated");
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
            var data = await _cupboardService.GetByIdAsync(id, token);
            var mappedData = _mapper.Map<DeleteCupboard>(data);
            await _cupboardService.DeleteAsync(mappedData, token);
            return Ok("Cupboard deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken token,
        bool includeModel = true
    )
    {
        try
        {
            var smt = await _cupboardService.GetAsync(token, includeModel);

            var result = _mapper.Map<List<GetCupboardResponse>>(smt);


            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token, bool includeModel = true)
    {
        try
        {
            var cupboard = await _cupboardService.GetByIdAsync(id, token, includeModel);

            return Ok(cupboard);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}