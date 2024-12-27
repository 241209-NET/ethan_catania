using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Service;

public interface ITableService{
    
    Task<Table> CreateNewTable(Table newTable);

    IEnumerable<Table> GetAllTables();

    Table? GetTableById(int id);

    Table UpdateTableStatus(string status);

    void DeleteTableById(int id);
}

public interface ISectionService{

    Task<Section> CreateNewSection(Section section);

    IEnumerable<Section> GetAllSections();

    IEnumerable<Table> GetTablesInSection(int id);

    void DeleteSectionById(int id);

}
public interface IServerService{

    Task<Server> CreateNewServer(Server server);

    IEnumerable<Server> GetAllServers();

    IEnumerable<Server> GetAvailableServers();

    int GetGuestTotalById(int id);
}