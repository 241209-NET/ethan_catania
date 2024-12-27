using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class TableService : ITableService
{
    public Task<Table> CreateNewTable(Table newTable)
    {
        throw new NotImplementedException();
    }

    public void DeleteTableById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Table> GetAllTables()
    {
        throw new NotImplementedException();
    }

    public Table? GetTableById(int id)
    {
        throw new NotImplementedException();
    }

    public Table UpdateTableStatus(string status)
    {
        throw new NotImplementedException();
    }
}
