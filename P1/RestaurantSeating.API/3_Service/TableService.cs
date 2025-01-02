using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantSeating.API.Exceptions;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    private readonly List<string> allowedStatus =  [ "OPEN", "OCCUPIED", "RESERVED" ];
    private readonly List<string> allowedAccess =  [ "WHEELCHAIR", "BOOTH", "TABLE" ];

    public TableService(ITableRepository tableRepository)
        => _tableRepository = tableRepository;

    public Table CreateNewTable(Table newTable)
    {
        if(newTable.Table_numPK < 0 )
            throw new InvalidIdException("Invalid ID");

        if (!allowedStatus.Contains(newTable.Status))
            throw new InvalidStatusException("Invalid status");

        if (newTable.Access != null)
        {
            foreach (var a in newTable.Access)
            {
                if (!allowedAccess.Contains(a))
                    throw new InvalidAccessException("Invalid access");
            }
        }

        if(newTable.Num_seats < 0 || newTable.Num_seats > 8)
            throw new InvalidNumSeatsException("Invalid capacity"); 

        return _tableRepository.CreateNewTable(newTable);
    }

// 0 OR MANY TABLES
    public List<Table> GetAllTables()
    {
        return _tableRepository.GetAllTables().ToList();
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

    public Table UpdateTableStatus(int id, string status)
    {
        GetTableById(id); // IF NULL EXCEPTION WILL BE THROWN

        if (!allowedStatus.Contains(status)) throw new InvalidStatusException("Invalid status");

        return _tableRepository.UpdateTableStatus(id, status)!;
    }

    public Table UpdateServer(int id, int server)
    {
        GetTableById(id); // IF NULL EXCEPTION WILL BE THROWN

        if(server < 0) throw new InvalidIdException("Invalid ID");

        return _tableRepository.UpdateServer(id,server)!;
    }
}
