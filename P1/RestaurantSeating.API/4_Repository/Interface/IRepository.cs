using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;


public interface ITableRepository{

    Task<Table> CreateNewTable(Table newTable);

    IEnumerable<Table> GetAllTables();

    Table? GetTableById(int id);

    Table UpdateTableStatus(string status);

    void DeleteTableById(int id);
    
}

public interface ISectionRepository{

    Task<Section> CreateNewSection(Section section);

    IEnumerable<Section> GetAllSections();

    IEnumerable<Table> GetTablesInSection(int id);

    void DeleteSectionById(int id);

}
public interface IServerRepository{

    Task<Server> CreateNewServer(Server server);

    IEnumerable<Server> GetAllServers();

    IEnumerable<Server> GetAvailableServers();

    int GetGuestTotalById(int id);
    

}

