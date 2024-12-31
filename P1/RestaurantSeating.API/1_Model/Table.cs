namespace RestaurantSeating.API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Table
{
    public Table(int section_FK, string[] access, int num_seats, int server_FK)
    {
        Section_FK = section_FK;
        Access = access;
        Num_seats = num_seats;
        Server_FK = server_FK;
    }


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Table_numPK { get; set; }

    [JsonIgnore]
    public string Status { get; set; } = "OPEN";

    [Required(ErrorMessage = "Section Number is required.")]
    public int Section_FK { get; set; }

    [Required(ErrorMessage = "Access is required.")]
    public string[] Access { get; set; }

    [Required(ErrorMessage = "Number of Seats is required.")]
    public int Num_seats { get; set; }

    [Required(ErrorMessage = "Server Number is required.")]
    public int Server_FK { get; set; } = 0;
}