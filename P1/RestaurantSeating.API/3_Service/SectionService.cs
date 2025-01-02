
using RestaurantSeating.API.Exceptions;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Repository;

namespace RestaurantSeating.API.Service;

public class SectionService(ISectionRepository sectionRepository, IServerRepository serverRepository) : ISectionService
{
    private readonly ISectionRepository _sectionRepository = sectionRepository;

    private readonly IServerRepository _serverRepository = serverRepository;

    private readonly List<string> allowed = [ "BOOTH", "WHEELCHAIR", "TABLE" ];

    public Section CreateNewSection(Section section)
    {
        
        if (section.Access != null)
        {
            foreach (var a in section.Access)
            {
                if (!allowed.Contains(a))
                    throw new InvalidAccessException("Invalid access");
            }
        }

        if(section.Server_FK < 0 )
            throw new InvalidServerIdException("Invalid server id");
        
        if( section.Num_tables < 0)
            throw new InvalidNumTablesException("Invalid number of seats");

        return _sectionRepository.CreateNewSection(section);
    }

    public void DeleteSectionById(int id)
    {
        GetSectionById(id); //Will throw exception if section does not exist

         _sectionRepository.DeleteSectionById(id);
    }

    public List<Section> GetAllSections()
    {
        return _sectionRepository.GetAllSections();
    }

    public List<Table> GetTablesInSection(int id) 
    {
        GetSectionById(id); //Will throw exception if section does not exist

        return _sectionRepository.GetTablesInSection(id);
    }

    public List<int> GetSectionsWithOpenTables() 
    {
        return _sectionRepository.GetSectionsWithOpenTables();
    }

    public Section GetSectionById(int id)
    {
        return _sectionRepository.GetSectionById(id) ?? throw new DoesNotExistException("Section does not exist");
    }

    public Section UpdateServer(int id ,int server)
    {
        GetSectionById(id); //Will throw exception if section does not exist  

        if(server < 0)
            throw new InvalidServerIdException("Invalid server id"); 

        if(_serverRepository.GetServerById(server) == null)
            throw new DoesNotExistException("Server does not exist");

        

        return _sectionRepository.UpdateServer(id,server);
    }

    public Section UpdateAccess(int id ,string[] access)
    {
        GetSectionById(id); //Will throw exception if section does not exist

        foreach(var a in access)
        {
            if(!allowed.Contains(a))
                throw new InvalidAccessException("Invalid access");
        }

        return _sectionRepository.UpdateAccess(id, access);
    }
}