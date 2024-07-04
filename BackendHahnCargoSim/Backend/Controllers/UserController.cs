using Backend.Model;
using Backend.UnitOfService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private readonly IUnitOfServices _unitOfService;
    
    
    public UserController(IUnitOfServices unitOfService)
    {
        _unitOfService = unitOfService;
    }
    
    
    
    
    
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserAuthenticate model)
    {
        if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest("Model values must not be empty");
        }
        try
        {
            UserToken loginResponse = await _unitOfService.User.Login(model);
            return Ok(loginResponse);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Log the exception details here
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
        }
    }
    
    
}