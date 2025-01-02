using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;
using RestaurantSeating.API.Utilities;

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
    public  IActionResult CreateNewTable([FromBody] PostTableDto newTable){
        var t =  _tableService.CreateNewTable(
            new Table(  newTable.Status,
                        newTable.Section_FK,
                        newTable.Access,
                        newTable.Num_seats, 
                        newTable.Server_FK));
        return Ok($"Successfully Created New Table"); 
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
    [Route("STATUS")]

    public IActionResult UpdateTableStatus([FromBody] UpdateStatusDto Dto){
        var updatedTable = _tableService.UpdateTableStatus(Dto.Id_PK, Dto.Status);
        if (updatedTable != null)
        {
            return Ok($"Successfully Updated Table {updatedTable.Table_numPK}");
        }
        return NotFound("Could Not Find Table");
    }

    [HttpPatch]
    [Route("SERVER")]
    public IActionResult UpdateServer([FromBody] UpdateServerDto Dto){
        var updatedTable = _tableService.UpdateServer(Dto.Id_PK, Dto.Server_FK);
        if (updatedTable != null)
        {
            return Ok($"Successfully Updated Table {updatedTable.Table_numPK}");
        }
        return NotFound("Could Not Find Table");
    }
}