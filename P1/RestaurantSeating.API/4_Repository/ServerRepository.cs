using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class ServerRepository(RestaurantContext context) : IServerRepository
{
    private readonly RestaurantContext _context = context;

    public Server CreateNewServer(Server server)
    {
        _context.Add(server);
        _context.SaveChanges();
        return server;   
    }

    public List<Server> GetAllServers()
    {
        return _context.Servers.ToList();
    }

    public Server? GetServerById(int id)
    {
        return _context.Servers.Find(id);
    }

    public List<Server> GetAvailableServers()
    {
       return _context.Servers.Where(s => s.IsAvailable).ToList();
    }
    
}