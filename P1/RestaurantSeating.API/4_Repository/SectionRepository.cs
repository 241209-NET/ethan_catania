using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Repository;

public class SectionRepository(RestaurantContext context) : ISectionRepository
{

    private readonly RestaurantContext _context = context;

    public Section CreateNewSection(Section section)
    {
        _context.Add(section);
        _context.SaveChanges();
        return section;
        
    }

    public void DeleteSectionById(int id)
    {
        var section = GetSectionById(id);
        _context.Remove(section!);
        _context.SaveChanges();
    }

    public List<Section> GetAllSections()
    {
        return _context.Sections.ToList();
    }

    public List<Table> GetTablesInSection(int id)
    {
        return _context.Tables.Where(t => t.Table_numPK == id)
                              .ToList();
    }

    public Section? GetSectionById(int id)
    {
        return _context.Sections.Find(id);
    }

    public List<int> GetSectionsWithOpenTables()
    {
        return _context.Sections
                    .Where(s => s.Tables.Any(t => t.Status == "OPEN"))
                    .Select(s => s.Id_PK)
                    .ToList();
    }

    public Section UpdateServer(int id, int server)
    {
        var s = GetSectionById(id);
        s!.Server_FK = server;
        _context.Update(s);
        _context.SaveChanges();
        return s;
    }

    public Section UpdateAccess(int id, string[] access)
    {
        var s = GetSectionById(id);
        s!.Access = access;
        _context.Update(s);
        _context.SaveChanges();
        return s;
    }

}