using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class TableRepository : ITableRepository
{

    private readonly RestaurantContext _context;

    public TableRepository(RestaurantContext context) => _context = context;


    public List<Table> GetAllTables()
    {
       return _context.Tables.ToList();
    }
    public Table CreateNewTable(Table newTable)
    {
        _context.Add(newTable);
        _context.SaveChanges();
        return newTable;
    }

    public void DeleteTableById(int id)
    {
        var table = GetTableById(id);
        _context.Remove(table!);
        _context.SaveChanges();
    }



    public Table? GetTableById(int id)
    {
        return _context.Tables.FirstOrDefault(t => t.Table_numPK == id);
    }

    public Table UpdateTableStatus(int id, string status)
    {
        var t = GetTableById(id);
        t!.Status = status;
        _context.Update(t);
        _context.SaveChanges();
        return t;
    }

    public Table UpdateServer(int id, int server)
    {
        var t = GetTableById(id);
        t!.Server_FK = server;
        _context.Update(t);
        _context.SaveChanges();
        return t;
    }

}