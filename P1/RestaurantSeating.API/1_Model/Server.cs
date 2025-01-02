namespace RestaurantSeating.API.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Server
{
    public Server() { }
    public Server(int id, string name, bool isAvailable){
        Id_PK = id;
        Name = name;
        IsAvailable = isAvailable;
    }

    public Server( string name, bool isAvailable){
        Name = name;
        IsAvailable = isAvailable;
    }
    
    [Key]
    [Required(ErrorMessage = "Server ID is required.")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_PK { get; set; } = 0;
    public string Name { get; set; } = "";

    public bool IsAvailable {get; set;} = false;
}