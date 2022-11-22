using AutoMapper;
using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.RegisterServiceOutput;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class RegisterService : IRegisterService
{
    private readonly ICreateUserService _createUser;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public RegisterService(UserManager<AppUser> userManager, ICreateUserService createUser, IMapper mapper)
    {
        _userManager = userManager;
        _createUser = createUser;
        _mapper = mapper;
    }


    public async Task<RegisterServiceOutput> RegisterLogic(RegisterModelOutput model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        var user = _createUser.Create(model);
        var mappedData = _mapper.Map<AppUser>(user);

        var result = await _userManager.CreateAsync(mappedData, model.Password);
        var registerServiceOutput = new RegisterServiceOutput();
        var mappedUser = _mapper.Map<UserOutput>(userExists);
        registerServiceOutput.UserOutput = mappedUser;
        registerServiceOutput.Result = result;
        return registerServiceOutput;
    }
}