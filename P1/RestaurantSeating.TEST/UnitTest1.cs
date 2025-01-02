
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;
using RestaurantSeating.API.Repository;
using Moq;
using RestaurantSeating.API.Exceptions;

namespace RestaurantSeating.TEST;
public class UnitTest1
{


    [Fact]
    public void CreateNewTable()
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
           new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];
        Table table = new (5,"OPEN" , 1, ["WHEELCHAIR"], 4, 1);

        mock.Setup(m => m.CreateNewTable(It.IsAny<Table>()))
            .Callback((Table t) => tables.Add(t))  
            .Returns(table);

        // Act
        var t = _tableService.CreateNewTable(table);

        // Assert
        Assert.Contains(table, tables);
        mock.Verify(m => m.CreateNewTable(It.IsAny<Table>()), Times.Once());
    }

    [Fact]
    public void CreateNewTableInvalidId()
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];
        Table table = new (-1, " OPEN", 1, ["WHEELCHAIR"], 4, 1);

        mock.Setup(m => m.CreateNewTable(It.IsAny<Table>()))
            .Callback((Table t) => tables.Add(t))  
            .Returns(table);

        // Assert
        Assert.Throws<InvalidIdException>(() => _tableService.CreateNewTable(table));
        mock.Verify(m => m.CreateNewTable(It.IsAny<Table>()), Times.Never());
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(9)]
    public void CreateNewTable_InvalidNumSeats(int numSeats)
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];
        Table table = new (5,"OPEN", 5, ["WHEELCHAIR"], numSeats, 1);

        mock.Setup(m => m.CreateNewTable(It.IsAny<Table>()))
            .Callback((Table t) => tables.Add(t))  
            .Returns(table);

        // Act and Assert
        Assert.Throws<InvalidNumSeatsException>(() => _tableService.CreateNewTable(table));
        mock.Verify(m => m.CreateNewTable(It.IsAny<Table>()), Times.Never());
    }

[Theory]
    [InlineData("WHEEL")]
    [InlineData("")]
    [InlineData(null)]
    public void CreateNewTable_InvalidAccess(string access)
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];
        Table table = new (5,"OPEN", 1, [access], 4, 1);

        mock.Setup(m => m.CreateNewTable(It.IsAny<Table>()))
            .Callback((Table t) => tables.Add(t))  
            .Returns(table);

        // Act and Assert
        Assert.Throws<InvalidAccessException>(() => _tableService.CreateNewTable(table));
    }

    [Theory]
    [InlineData("WHEEL")]
    [InlineData("CLEAN")]
    public void CreateNewTable_InvalidStatus(string status)
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];
        Table table = new (5,status, 1, ["WHEELCHAIR"], 4, 1);

        mock.Setup(m => m.CreateNewTable(It.IsAny<Table>()))
            .Callback((Table t) => tables.Add(t))  
            .Returns(table);

        // Act and Assert
        Assert.Throws<InvalidStatusException>(() => _tableService.CreateNewTable(table));
    }
    [Fact]
    public void GetAllTables()
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetAllTables())
            .Returns(tables);

        // Act
        var t = _tableService.GetAllTables();

        // Assert
        Assert.Equal(tables, t);
        mock.Verify(m => m.GetAllTables(), Times.Once());
    }

    [Fact]
    public void DeleteTableById()
    {
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];


        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
            .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        mock.Setup(m => m.DeleteTableById(It.IsAny<int>())) 
            .Callback((int id) => tables.Remove(tables.Find(t => t.Table_numPK == id))); 

        mock.Setup(m => m.GetAllTables()).Returns(tables);

        // Act

        _tableService.DeleteTableById(1);
        var tableList = _tableService.GetAllTables().ToList();

        // Assert
        Assert.DoesNotContain(tables.Find(t => t.Table_numPK == 1), tableList);
        mock.Verify(m => m.DeleteTableById(It.IsAny<int>()), Times.Once());
       
    }

    [Fact]
    public void UpdateServer(){
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
                .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var t = tables.Find(t => t.Table_numPK == id);
                t.Server_FK = server;
                return t;
            });

        // Act
        var t = _tableService.UpdateServer(1, 2);

        // Assert
        Assert.Equal(2, t.Server_FK);
        mock.Verify(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void UpdateStatus(){
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
                .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        mock.Setup(m => m.UpdateTableStatus(It.IsAny<int>(), It.IsAny<string>()))
            .Returns((int id, string status) => {
                var t = tables.Find(t => t.Table_numPK == id);
                t.Status = status;
                return t;
            });

        // Act
        var t = _tableService.UpdateTableStatus(1, "OCCUPIED");

        // Assert
        Assert.Equal("OCCUPIED", t.Status);
        mock.Verify(m => m.UpdateTableStatus(It.IsAny<int>(), It.IsAny<string>()), Times.Once());

    }

    [Fact]
    public void UpdateInvalidStatus(){
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
                .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        mock.Setup(m => m.UpdateTableStatus(It.IsAny<int>(), It.IsAny<string>()))
            .Returns((int id, string status) => {
                var t = tables.Find(t => t.Table_numPK == id);
                t.Status = status;
                return t;
            });


        // Assert
        Assert.Throws<InvalidStatusException>(() => _tableService.UpdateTableStatus(1, "FAIL"));
        mock.Verify(m => m.UpdateTableStatus(It.IsAny<int>(), It.IsAny<string>()), Times.Never());

    }
    [Fact]
    public void UpdateInvalidServer(){
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
                .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var t = tables.Find(t => t.Table_numPK == id);
                t.Server_FK = server;
                return t;
            });


        // Assert
        Assert.Throws<InvalidIdException>(() => _tableService.UpdateServer(1, -1));
        mock.Verify(m => m.UpdateTableStatus(It.IsAny<int>(), It.IsAny<string>()), Times.Never());

    }

    [Fact]
    public void GetTableById(){
        Mock<ITableRepository> mock = new();
        TableService _tableService = new(mock.Object);
    
        // Arrange

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetTableById(It.IsAny<int>()))
                .Returns((int id) => tables.FirstOrDefault(t => t.Table_numPK == id));

        // Act
        var t = _tableService.GetTableById(1);

        // Assert
        Assert.Equal(tables[0], t);
        mock.Verify(m => m.GetTableById(It.IsAny<int>()), Times.Once());

    }


    [Fact]
    public void GetServerById(){
        Mock<IServerRepository> mock = new();
        ServerService _serverService = new(mock.Object);
    
        // Arrange

        List<Server> server = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => server.FirstOrDefault(t => t.Id_PK == id));

        // Act  
        var s = _serverService.GetServerById(1);

        // Assert
        Assert.Equal(server[0], s);
        mock.Verify(m => m.GetServerById(It.IsAny<int>()), Times.Once());

    }


    [Fact]
    public void CreateNewServer(){
        Mock<IServerRepository> mock = new();
        ServerService _serverService = new(mock.Object);
    
        // Arrange

        List<Server> server = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        Server s = new (5, "Jack", true);

        mock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => server.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.CreateNewServer(It.IsAny<Server>()))
            .Callback((Server s) => server.Add(s)).Returns(s);

        // Act
        var serv = _serverService.CreateNewServer(s);

        // Assert
        Assert.Contains(serv, server);

    }
    
    [Fact]
    public void GetAllServers(){
        Mock<IServerRepository> mock = new();
        ServerService _serverService = new(mock.Object);
    
        // Arrange

        List<Server> server = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetAllServers())
                .Returns(server);

        // Act
        var s = _serverService.GetAllServers();

        // Assert
        Assert.Equal(server, s);
        mock.Verify(m => m.GetAllServers(), Times.Once());

    }

    [Fact]
    public void GetAvailableServers(){
        Mock<IServerRepository> mock = new();
        ServerService _serverService = new(mock.Object);
    
        // Arrange

        List<Server> server = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetAvailableServers())
                .Returns(server.Where(s => s.IsAvailable).ToList());

        // Act
        var s = _serverService.GetAvailableServers();

        // Assert
        Assert.Equal(server.Where(s => s.IsAvailable).ToList(), s);
        mock.Verify(m => m.GetAvailableServers(), Times.Once());

    }

    [Fact]
    public void CreateNewSection(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        Section s = new (5, 5, 1,["WHEELCHAIR"]);

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.CreateNewSection(It.IsAny<Section>()))
            .Callback((Section s) => sections.Add(s)).Returns(s);

        // Act
        var sec = _sectionService.CreateNewSection(s);

        // Assert
        Assert.Contains(sec, sections);

    }

    [Fact]
    public void CreateNewSectionInvalidServer(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        Section s = new (5, 5, -1,["WHEELCHAIR"]);

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.CreateNewSection(It.IsAny<Section>()))
            .Callback((Section s) => sections.Add(s)).Returns(s);

        // Assert
        Assert.Throws<InvalidServerIdException>(() => _sectionService.CreateNewSection(s));
        mock.Verify(m => m.CreateNewSection(It.IsAny<Section>()), Times.Never());

    }

    [Fact]
    public void CreateNewSectionInvalidNumTables(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        Section s = new (5, -1, 1,["WHEELCHAIR"]);

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.CreateNewSection(It.IsAny<Section>()))
            .Callback((Section s) => sections.Add(s)).Returns(s);

        // Assert
        Assert.Throws<InvalidNumTablesException>(() => _sectionService.CreateNewSection(s));
        mock.Verify(m => m.CreateNewSection(It.IsAny<Section>()), Times.Never());

    }

    [Theory]
    [InlineData("WHEEL")]
    [InlineData("")]
    public void CreateNewSectionInvalidAccess(string access){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        Section s = new (5, 5, 1,[access]);

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.CreateNewSection(It.IsAny<Section>()))
            .Callback((Section s) => sections.Add(s)).Returns(s);

        // Act and Assert
        Assert.Throws<InvalidAccessException>(() => _sectionService.CreateNewSection(s));
        mock.Verify(m => m.CreateNewSection(It.IsAny<Section>()), Times.Never());

    }

    [Fact]
    public void DeleteSectionById(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.DeleteSectionById(It.IsAny<int>()))
            .Callback((int id) => sections.Remove(sections.Find(s => s.Id_PK == id)));

        mock.Setup(m => m.GetAllSections()).Returns(sections);

        // Act
        _sectionService.DeleteSectionById(1);
        var sectionList = _sectionService.GetAllSections().ToList();

        // Assert
        Assert.DoesNotContain(sections.Find(s => s.Id_PK == 1), sectionList);
        mock.Verify(m => m.DeleteSectionById(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void GetAllSections(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetAllSections())
                .Returns(sections);

        // Act
        var s = _sectionService.GetAllSections();

        // Assert
        Assert.Equal(sections, s);
        mock.Verify(m => m.GetAllSections(), Times.Once());

    }

    [Fact]
    public void GetTablesInSection(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        List<Table> tables = [
            new Table(1,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(2,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(3,"OPEN" , 1, ["WHEELCHAIR"], 4, 1),
            new Table(4, "OPEN" , 1, ["WHEELCHAIR"], 4, 1)
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        mock.Setup(m => m.GetTablesInSection(It.IsAny<int>()))
            .Returns((int id) => tables.Where(t => t.Section_FK == id).ToList());

        // Act
        var t = _sectionService.GetTablesInSection(1);

        // Assert
        Assert.Equal(tables.Where(t => t.Section_FK == 1).ToList(), t);
        mock.Verify(m => m.GetTablesInSection(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void GetSectionById(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));
        
        // Act
        var s = _sectionService.GetSectionById(1);

        // Assert
        Assert.Equal(sections[0], s);
        mock.Verify(m => m.GetSectionById(It.IsAny<int>()), Times.Once());

    }


    [Fact]
    public void UpdateSectionServer(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        List<Server> servers = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        serverMock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => servers.FirstOrDefault(s => s.Id_PK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Server_FK = server;
                return s;
            });

        // Act
        var sec = _sectionService.UpdateServer(1, 2);

        // Assert
        Assert.Equal(2, sec.Server_FK);
        mock.Verify(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void UpdateSectionServerInvalidServer(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        List<Server> servers = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        serverMock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => servers.FirstOrDefault(s => s.Id_PK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Server_FK = server;
                return s;
            });

        // Assert
        Assert.Throws<InvalidServerIdException>(() => _sectionService.UpdateServer(1, -1));
        mock.Verify(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()), Times.Never());

    }

    [Fact]
    public void UpdateSectionSectionDoesNotExist(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        List<Server> servers = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        serverMock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => servers.FirstOrDefault(s => s.Id_PK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Server_FK = server;
                return s;
            });

        // Assert
        Assert.Throws<DoesNotExistException>(() => _sectionService.UpdateServer(5, 2));
        mock.Verify(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void UpdateSectionServerDoesNotExist(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        List<Server> servers = [
            new Server(1, "John", true),
            new Server(2, "Jane", false),
            new Server(3, "Jim", true),
            new Server(4, "Jill", false)
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        serverMock.Setup(m => m.GetServerById(It.IsAny<int>()))
                .Returns((int id) => servers.FirstOrDefault(s => s.Id_PK == id));

        mock.Setup(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int id, int server) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Server_FK = server;
                return s;
            });

        // Assert
        Assert.Throws<DoesNotExistException>(() => _sectionService.UpdateServer(1, 5));
        mock.Verify(m => m.UpdateServer(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void UpdateAccess(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        mock.Setup(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()))
            .Returns((int id, string[] access) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Access = access;
                return s;
            });

        // Act
        var sec = _sectionService.UpdateAccess(1, ["WHEELCHAIR", "BOOTH"]);

        // Assert
        Assert.Equal(["WHEELCHAIR", "BOOTH"], sec.Access);
        mock.Verify(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()), Times.Once());

    }

    [Fact]
    public void UpdateAccessInvalidAccess(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        mock.Setup(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()))
            .Returns((int id, string[] access) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Access = access;
                return s;
            });

        // Assert
        Assert.Throws<InvalidAccessException>(() => _sectionService.UpdateAccess(1, ["WHEEL"]));
        mock.Verify(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()), Times.Never());

    }

    [Fact]
    public void UpdateAccessSectionDoesNotExist(){
        Mock<ISectionRepository> mock = new();
        Mock<IServerRepository> serverMock = new();
        SectionService _sectionService = new(mock.Object, serverMock.Object);
    
        // Arrange

        List<Section> sections = [
            new Section(1, 5, 1,["WHEELCHAIR"]),
            new Section(2, 5, 1,["WHEELCHAIR"]),
            new Section(3, 5, 1,["WHEELCHAIR"]),
            new Section(4, 5, 1,["WHEELCHAIR"])
        ];

        mock.Setup(m => m.GetSectionById(It.IsAny<int>()))
                .Returns((int id) => sections.FirstOrDefault(t => t.Id_PK == id));

        mock.Setup(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()))
            .Returns((int id, string[] access) => {
                var s = sections.Find(s => s.Id_PK == id);
                s.Access = access;
                return s;
            });

        // Assert
        Assert.Throws<DoesNotExistException>(() => _sectionService.UpdateAccess(5, ["WHEELCHAIR", "BOOTH"]));
        mock.Verify(m => m.UpdateAccess(It.IsAny<int>(), It.IsAny<string[]>()), Times.Never());

    }

}