namespace RestaurantSeating.API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Table
{
    public Table() { }
    public Table (int PK, string status, int section_FK, string[] access, int num_seats, int server_FK){
        Table_numPK = PK;
        Status = status;
        Section_FK = section_FK;
        Access = access;
        Num_seats = num_seats;
        Server_FK = server_FK;
    } 

        public Table ( string status, int section_FK, string[] access, int num_seats, int server_FK){
        Status = status;
        Section_FK = section_FK;
        Access = access;
        Num_seats = num_seats;
        Server_FK = server_FK;
    } 

    

    [Key]
    [Required(ErrorMessage = "Table Number is required.")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Table_numPK { get; set; } = 0;

    public string Status { get; set; }  = "OPEN";
    [Required(ErrorMessage = "Section Number is required.")]
    public int Section_FK { get; set; } = 0;

    public string[] Access { get; set; } = [];

    [Required(ErrorMessage = "Number of Seats is required.")]
    public int Num_seats { get; set; } = 0;

    [Required(ErrorMessage = "Server Number is required.")]
    public int Server_FK { get; set; } = 0;
}