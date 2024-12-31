using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Service;

public interface ITableService{
    
    Task<Table> CreateNewTable(Table newTable);

    IEnumerable<Table> GetAllTables();

    Table GetTableById(int id);

    Table UpdateTableStatus(Table table);

    Table UpdateServer(Table table);

    void DeleteTableById(int id);
}

public interface ISectionService{

    Task<Section> CreateNewSection(Section section);

    IEnumerable<Section> GetAllSections();

    IEnumerable<Table> GetTablesInSection(int id);

    void DeleteSectionById(int id);

    Section GetSectionById(int id);

    List<int> GetSectionsWithOpenTables();

    Section UpdateServer(int id ,int server);

    Section UpdateAccess(int id, string[] access);

}
public interface IServerService{

    Task<Server> CreateNewServer(Server server);

    IEnumerable<Server> GetAllServers();

    IEnumerable<Server> GetAvailableServers();

    Server GetServerById(int id);
}