namespace RestaurantSeating.API.Utilities;
public class UpdateStatusDto
{
    public int Id_PK { get; set; }
    public string Status { get; set; } = "OPEN";
}
