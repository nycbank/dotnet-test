using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using dotnet_test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_test.Controllers;

[Route("[controller]")]
[Produces("application/json")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpGet]
    public IActionResult GetToken()
    {
        var token = TokenService.GenerateToken();
        return Ok(token);
    }
    
}