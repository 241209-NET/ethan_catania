using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class SectionRepository : ISectionRepository
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