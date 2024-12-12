namespace MiniProj;
public class Menu
{
    /*
    Start method responisble for printing the rules and ensuring the player is ready to start. Will work if the player enters an upper or lowercase letter "y". 
    Returns a boolean to represent the choice of the player. 
    */
    public static bool Start(){
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("BlackJack! Get Closest to 21 without going over...");
        Console.WriteLine("Ready to Play? Enter Y.");
        Console.ResetColor();
        Console.WriteLine("\n");
        string? input = Console.ReadLine();
        if (input != "Y" && input != "y"){
            Console.WriteLine("No fun...");
            return false;
        }
        return true;
    }
}