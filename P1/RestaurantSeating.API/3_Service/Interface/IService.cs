using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Service;

public interface ITableService{
    
    Table CreateNewTable(Table newTable);

    List<Table> GetAllTables();

    Table GetTableById(int id);

    Table UpdateTableStatus(int id, string status);

    Table UpdateServer(int id, int server);

    void DeleteTableById(int id);
}

public interface ISectionService{

    Section CreateNewSection(Section section);

    List<Section> GetAllSections();

    List<Table> GetTablesInSection(int id);

    void DeleteSectionById(int id);

    Section GetSectionById(int id);

    List<int> GetSectionsWithOpenTables();

    Section UpdateServer(int id ,int server);

    Section UpdateAccess(int id, string[] access);

}
public interface IServerService{

    Server CreateNewServer(Server server);

    List<Server> GetAllServers();

    List<Server> GetAvailableServers();

    Server GetServerById(int id);
}