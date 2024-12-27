using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class TableRepository : ITableRepository
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