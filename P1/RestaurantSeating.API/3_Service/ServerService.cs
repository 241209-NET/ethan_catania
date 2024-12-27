using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class ServerService : IServerService
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
