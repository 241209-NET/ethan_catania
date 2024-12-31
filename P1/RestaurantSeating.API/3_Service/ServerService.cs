using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;
using RestaurantSeating.API.Exceptions;

namespace RestaurantSeating.API.Service;

public class ServerService(IServerRepository serverRepository) : IServerService
{
    private readonly IServerRepository _serverRepository = serverRepository;

    public Task<Server> CreateNewServer(Server server)
    {
        if(_serverRepository.GetServerById(server.Id_PK) != null)
            throw new AlreadyExistsException("Server already exists");

        
        return _serverRepository.CreateNewServer(server);
    }

    public IEnumerable<Server> GetAllServers()
    {
        return _serverRepository.GetAllServers();
    }

    public IEnumerable<Server> GetAvailableServers()
    {
        return _serverRepository.GetAvailableServers();
    }

    public Server GetServerById(int id)
    {
        return _serverRepository.GetServerById(id) ?? throw new DoesNotExistException("Server does not exist");
    }
}
