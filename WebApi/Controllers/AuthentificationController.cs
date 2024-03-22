using Application.Login;
using Application.Register;
using Application.Responses;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthentificationController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SneakerDbContext _context;
    private readonly TokenService _tokenService;

    public AuthentificationController(UserManager<ApplicationUser> userManager, SneakerDbContext context, TokenService tokenService, ILogger<AuthentificationController> logger)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] Register request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new ApplicationUser { UserName = request.Username, Email = request.Email, Role = request.Role },
            request.Password!
        );

        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { email = request.Email, role = request.Role }, request);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] Login request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(request.Email!);
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

        if (userInDb is null)
        {
            return Unauthorized();
        }

        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();

        return Ok(new LoginResponse
        {
            Username = userInDb.UserName,
            Email = userInDb.Email,
            Token = accessToken,
        });
    }
}
