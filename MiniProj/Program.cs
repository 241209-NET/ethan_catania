using System;

namespace MiniProj{
    class Program{
        /*
        Main method responsible for printing rules and calling Menu and GameManager class methods. Also prompts the user to keep playing after games finished.
        Will keep playing if the user inputs an upper or lower case letter "y". 
        */
        static void Main(string[] args){
            bool keepPlaying = true;
            if(Menu.Start()){
                while(keepPlaying){
                    Console.WriteLine($"The Winner is {GameManager.PlayGame()}!");
                    Console.WriteLine("Keep Playing? (y/n)");
                    string? input = Console.ReadLine();
                    if (input != "y" && input != "Y"){
                        keepPlaying = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n");
                        Console.WriteLine("    Thanks for Playing! =]    ");
                        Console.WriteLine("\n");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
