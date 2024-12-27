using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

namespace RestaurantSeating.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class TableController : ControllerBase {
    private readonly ITableService _tableService;

    public TableController(ITableService tableService) 
        => _tableService = tableService; 
    
    [HttpGet]

    public IActionResult GetAllTables(){
        var tableList = _tableService.GetAllTables();
        return Ok(tableList);
    }
}