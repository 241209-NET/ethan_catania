using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

namespace RestaurantSeating.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class TableController(ITableService tableService) : ControllerBase 
{
    private readonly ITableService _tableService = tableService;

    [HttpGet]

    public IActionResult GetAllTables(){
        var tableList = _tableService.GetAllTables();
        return Ok(tableList);
    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetTableById(int id){
        var table = _tableService.GetTableById(id);
        if (table != null)
        {
            return Ok(table);
            
        }
        return NotFound("Could Not Find Table");
    }
    [HttpPost]
    //PROB NEED DTO !!!!!~
    public async Task<IActionResult> CreateNewTable([FromBody] Table newTable){
        var t = await _tableService.CreateNewTable(newTable);
        return Ok($"Successfully Created Table {t.Table_numPK}"); 
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteTableById(int id){
        var table = _tableService.GetTableById(id);
        if (table != null)
        {
            _tableService.DeleteTableById(id);
            return Ok($"Successfully Deleted Table {table.Table_numPK}");
        }
        return NotFound("Could Not Find Table");
    }
    [HttpPatch]

//NEED TO CHECK DELETE AND PATCH 
    public IActionResult UpdateTableStatus([FromBody] Table table){
        var updatedTable = _tableService.UpdateTableStatus(table);
        if (updatedTable != null)
        {
            return Ok($"Successfully Updated Table {updatedTable.Table_numPK}");
        }
        return NotFound("Could Not Find Table");
    }
}