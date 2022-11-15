using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Services.Interfaces;
using core_web_api.Models.Request.CupboardModelRequest;
using core_web_api.Models.Response.CupboardModelResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace core_web_api.Controllers;

[Route("api/cupboard-model")]
[ApiController]
public class CupboardModelController : Controller
{
    private readonly ICupboardModelService _cupboardModelService;
    private readonly ILogger<CupboardModelController> _logger;
    private readonly IMapper _mapper;

    public CupboardModelController(ILogger<CupboardModelController> logger, IMapper mapper,
        ICupboardModelService cupboardModelService)
    {
        _logger = logger;
        _mapper = mapper;
        _cupboardModelService = cupboardModelService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([BindRequired] CancellationToken token)
    {
        try
        {
            var cupboardModel =
                _mapper.Map<IEnumerable<GetCupboardModelResponse>>(await _cupboardModelService.GetAsync(token));

            return Ok(cupboardModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(CancellationToken token, DeleteCupboardModelRequest cupboardModel)
    {
        try
        {
            var mappedData = _mapper.Map<DeleteCupboardModel>(cupboardModel);
            await _cupboardModelService.DeleteAsync(mappedData, token);
            return Ok("CupboardModel deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CancellationToken token, CreateCupboardModelRequest cupboardModel)
    {
        try
        {
            var mappedData = _mapper.Map<CreateCupboardModel>(cupboardModel);
            await _cupboardModelService.CreateAsync(mappedData, token);
            return Ok("CupboardModel created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}