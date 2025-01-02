
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;
using RestaurantSeating.API.Exceptions;

namespace RestaurantSeating.API.Service;

public class ServerService(IServerRepository serverRepository) : IServerService
{
    private readonly IServerRepository _serverRepository = serverRepository;

    public Server CreateNewServer(Server server)
    {
        return _serverRepository.CreateNewServer(server);
    }

    public List<Server> GetAllServers()
    {
        return _serverRepository.GetAllServers();
    }

    public List<Server> GetAvailableServers()
    {
        return _serverRepository.GetAvailableServers();
    }

    public Server GetServerById(int id)
    {
        return _serverRepository.GetServerById(id) ?? throw new DoesNotExistException("Server does not exist");
    }
}
