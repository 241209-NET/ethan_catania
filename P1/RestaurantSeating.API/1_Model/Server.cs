namespace RestaurantSeating.API.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Server(string name, bool isAvailable)
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id_PK { get; set; }
    public string Name { get; set; } = name;

    public bool IsAvailable {get; set;} = isAvailable;
}