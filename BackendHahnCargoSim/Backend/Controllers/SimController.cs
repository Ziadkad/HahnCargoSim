using Backend.Helper;
using Backend.UnitOfService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("[controller]")]
public class SimController : ControllerBase
{
    // this controller is just for test
    private readonly IUnitOfServices _unitOfService;
    
    
    public SimController(IUnitOfServices unitOfService)
    {
        _unitOfService = unitOfService;
    }
    
    [HttpGet("CoinAmount")]
    public async Task<IActionResult> CoinAmount([FromHeader] string token)
    {
        
        if (token == null)
        {
            return BadRequest(new { message = "You need to login" });
        }

        token = TokenHelper.TokenRegex(token);
        try
        {
            var response = await _unitOfService.User.CoinAmount(token);
            return Ok(response);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
        }
    }    
    [HttpPost("StartSim")]
    public async Task<IActionResult> Start([FromHeader] string token)
    {
        
        if (token == null)
        {
            return BadRequest(new { message = "You need to login" });
        }

        token = TokenHelper.TokenRegex(token);
        try
        {
            await _unitOfService.Sim.Start(token);
            return Ok(new { message = "Simulation started successfully" });
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
    
    [HttpPost("StopSim")]
    public async Task<IActionResult> Stop([FromHeader] string token)
    {
        
        if (token == null)
        {
            return BadRequest(new { message = "You need to login" });
        }

        token = TokenHelper.TokenRegex(token);
        try
        {
            await _unitOfService.Sim.Stop(token);
            return Ok(new { message = "Simulation stopped successfully" });
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