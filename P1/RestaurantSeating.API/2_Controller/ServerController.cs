using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

namespace RestaurantSeating.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class ServerController : ControllerBase {
    private readonly IServerService _serverService;

    public ServerController(IServerService serverService) 
        => _serverService = serverService; 
    
    [HttpGet]

    public IActionResult GetAllServers(){
        var serverList = _serverService.GetAllServers();
        return Ok(serverList);
    }
}