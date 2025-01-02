using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;


public interface ITableRepository{

    Table CreateNewTable(Table newTable);

    List<Table> GetAllTables();

    Table? GetTableById(int id);

    Table UpdateTableStatus(int id, string status);

    void DeleteTableById(int id);

    Table UpdateServer(int id ,int server);
    
}

public interface ISectionRepository{

    Section CreateNewSection(Section section);

    List<Section> GetAllSections();

    List<Table> GetTablesInSection(int id);

    List<int> GetSectionsWithOpenTables();

    void DeleteSectionById(int id);

    Section? GetSectionById(int id);

    Section UpdateServer(int id, int server);

    Section UpdateAccess(int id, string[] access);

}
public interface IServerRepository{

    Server CreateNewServer(Server server);

    List<Server> GetAllServers();

    List<Server> GetAvailableServers();

    Server? GetServerById(int id);


}

