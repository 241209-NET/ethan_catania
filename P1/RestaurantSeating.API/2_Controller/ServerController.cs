using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

namespace RestaurantSeating.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class ServerController(IServerService serverService) : ControllerBase {
    private readonly IServerService _serverService = serverService;

    [HttpGet]

    public IActionResult GetAllServers(){
        var serverList = _serverService.GetAllServers();
        return Ok(serverList);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetServerById(int id){
        var server = _serverService.GetServerById(id);
        if (server != null)
        {
            return Ok(server);
        }
        return NotFound("Could Not Find Server");
    }

    [HttpGet]
    [Route("AVAILABLE")]
    public IActionResult GetAvailableServers(){
        var serverList = _serverService.GetAvailableServers();
        return Ok(serverList);
    }

    [HttpPost]
    public  IActionResult CreateNewServer([FromBody] PostServerDto newServer){
        var s = _serverService.CreateNewServer(new Server(newServer.Name, newServer.IsAvailable));
        return Ok($"Successfully Created Server {s.Name}"); 
    }


}