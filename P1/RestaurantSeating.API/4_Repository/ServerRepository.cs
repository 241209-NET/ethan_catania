using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class ServerRepository(RestaurantContext context) : IServerRepository
{
    private readonly RestaurantContext _context = context;

    public Task<Server> CreateNewServer(Server server)
    {
        _context.Add(server);
        _context.SaveChanges();
        return Task.FromResult(server);   
    }

    public IEnumerable<Server> GetAllServers()
    {
        return _context.Servers.ToList();
    }

    public Server? GetServerById(int id)
    {
        return _context.Servers.Find(id);
    }

    public IEnumerable<Server> GetAvailableServers()
    {
       return _context.Servers.Where(s => s.IsAvailable).ToList();
    }
    
    public int GetCurrNumTables(int id)
    {
        return _context.Tables.Where(t => t.Server_FK == id).Count();
    }

}