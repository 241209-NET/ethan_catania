using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Exceptions;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    private readonly List<string> allowed =  [ "OPEN", "OCCUPIED", "RESERVED" ];

    public TableService(ITableRepository tableRepository)
        => _tableRepository = tableRepository;

    public Task<Table> CreateNewTable(Table newTable)
    {
        if(_tableRepository.GetTableById(newTable.Table_numPK) != null)
            throw new AlreadyExistsException("Table already exists");

        if(newTable.Table_numPK < 0 )
            throw new InvalidIdException("Invalid ID");

        if(!allowed.Contains(newTable.Status) && newTable.Status != null)
            throw new InvalidStatusException("Invalid status");

        if(newTable.Num_seats < 0 || newTable.Num_seats > 8)
            throw new InvalidNumSeatsException("Invalid capacity");

//NOT SURE ABOUT CREEATING TABLES WITHOUT A SERVER OR SECTION ASSIGNED 

        return _tableRepository.CreateNewTable(newTable);
    }

// 0 OR MANY TABLES
    public IEnumerable<Table> GetAllTables()
    {
        return _tableRepository.GetAllTables();
    }

    public void DeleteTableById(int id)
    {
        GetTableById(id); // IF NULL EXCEPTION WILL BE THROWN
        _tableRepository.DeleteTableById(id);
        
    }


    public Table GetTableById(int id)
    {
        return _tableRepository.GetTableById(id) ?? throw new DoesNotExistException("Table does not exist");
    }

    public Table UpdateTableStatus(Table table)
    {
        GetTableById(table.Table_numPK); // IF NULL EXCEPTION WILL BE THROWN

        if (!allowed.Contains(table.Status)) throw new Exception("Invalid status");

        return _tableRepository.UpdateTableStatus(table)!;
    }

    public Table UpdateServer(Table table)
    {
        GetTableById(table.Table_numPK); // IF NULL EXCEPTION WILL BE THROWN

        if(table.Server_FK < 0) throw new InvalidIdException("Invalid ID");

        return _tableRepository.UpdateServer(table)!;
    }
}
