namespace RestaurantSeating.API.Model;

public class Section {
    public required int Id_PK {get; set;}
    public required int Num_tables {get;set;}

    public int Server_FK {get; set;}

    public required string[] Access {get; set;} 

    public required List<Table> Tables {get; set;} 

}