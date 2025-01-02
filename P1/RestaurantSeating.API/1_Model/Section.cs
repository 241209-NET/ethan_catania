namespace RestaurantSeating.API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Section
{
    public Section() { }

    public Section(int id, int numTables, int serverFK, string[] access)
    {
        Id_PK = id;
        Num_tables = numTables;
        Server_FK = serverFK;
        Access = access;
    }
    public Section( int numTables, int serverFK, string[] access)
    {
        Num_tables = numTables;
        Server_FK = serverFK;
        Access = access;
    }
    [Key]
    [Required(ErrorMessage = "Section ID is required.")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_PK { get; set; } = 0;
    public int Num_tables { get; set; } = 0;

    public int Server_FK { get; set; } = 0;

    [Required(ErrorMessage = "Access is required.")]
    public string[] Access { get; set; } = [];

    [JsonIgnore]  
    public  List<Table> Tables { get; set; }
}