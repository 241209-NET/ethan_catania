using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;


public interface ITableRepository{

    Task<Table> CreateNewTable(Table newTable);

    IEnumerable<Table> GetAllTables();

    Table? GetTableById(int id);

    Table UpdateTableStatus(Table table);

    void DeleteTableById(int id);

    Table UpdateServer(Table table);
    
}

public interface ISectionRepository{

    Task<Section> CreateNewSection(Section section);

    IEnumerable<Section> GetAllSections();

    IEnumerable<Table> GetTablesInSection(int id);

    List<int> GetSectionsWithOpenTables();

    void DeleteSectionById(int id);

    Section? GetSectionById(int id);

    Section UpdateServer(int id, int server);

    Section UpdateAccess(int id, string[] access);

}
public interface IServerRepository{

    Task<Server> CreateNewServer(Server server);

    IEnumerable<Server> GetAllServers();

    IEnumerable<Server> GetAvailableServers();

    int GetCurrNumTables(int id);

    Server? GetServerById(int id);


}

