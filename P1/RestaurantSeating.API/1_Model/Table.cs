namespace RestaurantSeating.API.Model;

public class Table {
    public int Id_PK {get; set;}

    public required string Status { get; set;}
    public int Table_num {get;set;}

    public int Section_FK {get; set;}

    public required string[] Access {get; set;} 

}