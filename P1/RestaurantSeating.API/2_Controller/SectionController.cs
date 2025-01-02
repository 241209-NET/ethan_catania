using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;
using RestaurantSeating.API.Utilities;

namespace RestaurantSeating.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class SectionController : ControllerBase {
    private readonly ISectionService _sectionService;

    public SectionController(ISectionService sectionService) 
        => _sectionService = sectionService; 
    
    [HttpGet]

    public IActionResult GetAllSections(){
        var sectionList = _sectionService.GetAllSections();
        return Ok(sectionList);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetSectionById(int id){
        var section = _sectionService.GetSectionById(id);
        if (section != null)
        {
            return Ok(section);
        }
        return NotFound("Could Not Find Section");
    }

    [HttpPost]
    public IActionResult CreateNewSection([FromBody] PostSectionDto newSection){
        var s =  _sectionService.CreateNewSection(
            new Section(
                newSection.Num_tables,
                newSection.Server_FK,
                 newSection.Access));
        return Ok($"Successfully Created Section"); 
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteSectionById(int id){
        var section = _sectionService.GetSectionById(id);
        if (section != null)
        {
            _sectionService.DeleteSectionById(id);
            return Ok($"Successfully Deleted Section {section.Id_PK}");
        }
        return NotFound("Could Not Find Section");
    }

    [HttpPatch]
    [Route("SERVER")]
    public IActionResult UpdateServer([FromBody] UpdateServerDto updateServerDto){
        var updatedSection = _sectionService.UpdateServer(updateServerDto.Id_PK, updateServerDto.Server_FK);
        if (updatedSection != null)
        {
            return Ok($"Successfully Updated Section {updatedSection.Id_PK}");
        }
        return NotFound("Could Not Find Section");
    }

    [HttpPatch]
    [Route("ACCESS")]
    public IActionResult UpdateAccess([FromBody] UpdateAccessDto updateAccessDto){
        var updatedSection = _sectionService.UpdateAccess(updateAccessDto.Id_PK, updateAccessDto.Access);
        if (updatedSection != null)
        {
            return Ok($"Successfully Updated Section {updatedSection.Id_PK}");
        }
        return NotFound("Could Not Find Section");
    }

    [HttpGet]
    [Route("OPEN")]
    public IActionResult GetSectionsWithOpenTables(){
        var sectionList = _sectionService.GetSectionsWithOpenTables();
        return Ok(sectionList);
    }

    [HttpGet]
    [Route("{id}/tables")]
    public IActionResult GetTablesInSection(int id){
        var tableList = _sectionService.GetTablesInSection(id);
        return Ok(tableList);
    }


}