namespace RestaurantSeating.API.Model;

public class Server {
    public int Id_PK {get; set;}
    public required string Name {get;set;}
    public int Guest_total {get; set;} = 0;
    public  bool IsAvalible {get; set;} = false;

}