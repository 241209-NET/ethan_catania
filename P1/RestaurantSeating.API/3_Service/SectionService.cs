using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class SectionService : ISectionService
{
    public Task<Section> CreateNewSection(Section section)
    {
        throw new NotImplementedException();
    }

    public void DeleteSectionById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Section> GetAllSections()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Table> GetTablesInSection(int id)
    {
        throw new NotImplementedException();
    }
}