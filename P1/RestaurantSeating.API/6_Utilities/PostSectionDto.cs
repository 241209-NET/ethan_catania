namespace RestaurantSeating.API.Utilities;
public class PostSectionDto
{
    public int Server_FK { get; set; }
    public string[] Access { get; set; } = [];
    public int Num_tables { get; set; }
}