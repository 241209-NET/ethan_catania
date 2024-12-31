namespace RestaurantSeating.API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Section
{

    public Section() { }

    public Section( int server_FK, string[] access)
    {
        Server_FK = server_FK;
        Access = access;
    }

    public Section(string[] access)
    {
        Access = access;
    }

    public Section(int server_FK)
    {
        Server_FK = server_FK;
    }


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id_PK { get; set; }
    public int Num_tables { get; set; } = 0;

    public int Server_FK { get; set; } = 0;

    [Required(ErrorMessage = "Access is required.")]
    public string[] Access { get; set; } = [];

    [JsonIgnore]
    public  List<Table> Tables { get; set; } = [];
}