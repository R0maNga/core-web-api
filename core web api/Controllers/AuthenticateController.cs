using System.IdentityModel.Tokens.Jwt;
using BLL.Models.Output.AuthOutput;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace core_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IRegisterAdminService _adminService;

    private readonly ILoginService _loginService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IRegisterService _registerService;

    public AuthenticateController(ILoginService loginService, IRegisterService registerService,
        IRegisterAdminService adminService, IRefreshTokenService refreshTokenService)
    {
        _loginService = loginService;
        _registerService = registerService;
        _adminService = adminService;
        _refreshTokenService = refreshTokenService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelOutput model)
    {
        var data = await _loginService.LoginLogic(model);
        if (data != null)
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(data.Token),
                data.RefreshToken,
                Expiration = data.Token.ValidTo
            });

        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelOutput model)
    {
        var data = await _registerService.RegisterLogic(model);
        if (data.UserOutput != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseOutput { Status = "Error", Message = "User already exists!" });

        if (!data.Result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseOutput
                { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        return Ok(new ResponseOutput { Status = "Success", Message = "User created successfully!" });
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModelOutput model)
    {
        var data = await _registerService.RegisterLogic(model);
        if (data.UserOutput != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseOutput { Status = "Error", Message = "User already exists!" });

        if (!data.Result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseOutput
                { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        await _adminService.CreateAdmin(model);

        return Ok(new ResponseOutput { Status = "Success", Message = "User created successfully!" });
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModelOutput tokenModel)
    {
        if (tokenModel is null) return BadRequest("Invalid client request");

        var refreshToken = tokenModel.RefreshToken;

        var data = await _refreshTokenService.CreateRefreshToken(tokenModel);
        if (data == null) return BadRequest("Invalid access token or refresh token");

        if (data.ClaimsPrincipal == null) return BadRequest("Invalid access token or refresh token");

        return new ObjectResult(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(data.NewAccessToken),
            refreshToken = data.NewRefreshToken
        });
    }
}