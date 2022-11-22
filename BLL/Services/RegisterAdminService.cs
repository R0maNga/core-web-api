using AutoMapper;
using BLL.Models.Output.AuthOutput;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class RegisterAdminService : IRegisterAdminService
{
    private readonly ICreateUserService _createUser;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public RegisterAdminService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
        ICreateUserService createUser, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _createUser = createUser;
        _mapper = mapper;
    }

    public async Task CreateAdmin(RegisterModelOutput model)
    {
        if (!await _roleManager.RoleExistsAsync(UserRolesOutput.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRolesOutput.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRolesOutput.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRolesOutput.User));

        var user = _createUser.Create(model);
        var mappedData = _mapper.Map<AppUser>(user);
        if (await _roleManager.RoleExistsAsync(UserRolesOutput.Admin))
            await _userManager.AddToRoleAsync(mappedData, UserRolesOutput.Admin);
        if (await _roleManager.RoleExistsAsync(UserRolesOutput.Admin))
            await _userManager.AddToRoleAsync(mappedData, UserRolesOutput.User);
    }
}