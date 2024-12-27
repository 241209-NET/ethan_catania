using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class ServerRepository : IServerRepository
{
    public Task<Server> CreateNewServer(Server server)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Server> GetAllServers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Server> GetAvailableServers()
    {
        throw new NotImplementedException();
    }

    public int GetGuestTotalById(int id)
    {
        throw new NotImplementedException();
    }
}