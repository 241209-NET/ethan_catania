namespace MiniProj;

public class GameManager{

        private static readonly string D = "the DEALER";
        private static readonly string Y = "YOU";
        private static readonly string N = "NO ONE"; 
    /*
    Play game method responsible for controlling logic of a game of Blackjack. Process will terminate is either "Player" goes over 21 or if both players choose to stay.
    If either goes over 21, then the other player is the winner. If both players stay, then the larger score wins; with ties possible. The player can choose to hit,
    stay, or end the game at any point, while the dealer will always hit unless it has a score 17 or greater, in which case it will stay.
    returns a String to indicate the winner of a game. 

    TODO:
        - Should prob start with the player getting two cards and the dealer getting one card. 
        - Should implement the ability to place bets so that double down and splitting are possible.
        - The player should go first and continue going rather than a back and forth nature which gives the advantage to the player.
        - Abilty to have Ace cards be 1 or 11.
        - Ability to have more 10 valued cards than other cards and base the game off the rules of a deck rather than just random numbers. 
        - ...
    */
    public static string PlayGame(){

        int playerScore = 0;
        int dealerScore = 0;
        bool isPlayer = false;
        bool playerStayed = false;
        bool dealerStayed = false;

        while(!(dealerStayed && playerStayed)){
            if(isPlayer && !playerStayed){
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"YOU have {playerScore}.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The DEALER has {dealerScore}");
                Console.ResetColor();
                Console.WriteLine("Enter 1 to Hit, Enter 2 to Stay, Enter 3 to Quit");
                
                string? choice = Console.ReadLine();
                switch(choice){
                    case "1":  
                        int card = Dealer.DealCard(isPlayer);
                        playerScore += card;
                        break;
                    case "2":
                        playerStayed = true;
                        break;
                    case "3":
                        return D;
                    default:
                        isPlayer = !isPlayer;
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INVALID OPTION");
                        Console.ResetColor();
                        break;
                }
                
            } else if (!isPlayer && !dealerStayed){
                if (dealerScore > 16){
                    dealerStayed = true;
                    Console.WriteLine("\n");
                    Console.WriteLine($"The DEALER stayed at {dealerScore}");
                } else{
                    int card = Dealer.DealCard(isPlayer);
                    dealerScore += card;
                }
            } 
            if (playerScore > 21){
                return D;
            }
            if (dealerScore > 21){
                return Y;
            }

            isPlayer = !isPlayer;

        }
        
        if (dealerScore == playerScore){
            return N;
        }
        else if (dealerScore > playerScore){
            return D;
        } else{
            return Y;
        }
    }
}