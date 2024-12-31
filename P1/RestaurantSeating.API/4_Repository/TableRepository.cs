using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class TableRepository : ITableRepository
{

    private readonly RestaurantContext _context;

    public TableRepository(RestaurantContext context) => _context = context;


    public IEnumerable<Table> GetAllTables()
    {
       return _context.Tables.ToList();
    }
    public Task<Table> CreateNewTable(Table newTable)
    {
        _context.Add(newTable);
        _context.SaveChanges();
        return Task.FromResult(newTable);
    }

    public void DeleteTableById(int id)
    {
        var table = GetTableById(id);
        _context.Remove(table!);
        _context.SaveChanges();
    }



    public Table? GetTableById(int id)
    {
        return _context.Tables.Find(id);
    }

    public Table UpdateTableStatus(Table table)
    {
        var t = GetTableById(table.Table_numPK);
        t!.Status = table.Status;
        _context.Update(t);
        _context.SaveChanges();
        return t;

       
    }

    public Table UpdateServer(Table table)
    {
        var t = GetTableById(table.Table_numPK);
        t!.Server_FK = table.Server_FK;
        _context.Update(t);
        _context.SaveChanges();
        return t;
    }

}