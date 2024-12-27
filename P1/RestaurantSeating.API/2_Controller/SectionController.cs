using Microsoft.AspNetCore.Mvc;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

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
}