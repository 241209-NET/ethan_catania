public class PostTableDto{
     public string Status { get; set; }  = "OPEN";
    public int Section_FK { get; set; } = 0;

    public string[] Access { get; set; } = [];
    public int Num_seats { get; set; } = 0;

    public int Server_FK { get; set; } = 0;   
}