using System;

namespace MiniProj{
    class Program{

        static void Main(string[] args){
            Program program = new Program();
            Console.WriteLine("BlackJack");
            Console.WriteLine("Ready to Play? Enter Y.");
            string? input = Console.ReadLine();
            if (input != "Y" && input != "y"){
                Console.WriteLine("No fun...");
                return;
            }
            int playerScore = 0;
            int dealerScore = 0;
            bool isOver = false;
            bool isPlayer = false;
            string winner = "";
            while(!isOver){
                
                if(isPlayer){
                    Console.WriteLine($"You have {playerScore}. The Dealer has {dealerScore}");
                    Console.WriteLine("Enter 1 to Hit, Enter 2 to Stay, Enter 3 to Quit");
                    string? choice = Console.ReadLine();
                    switch(Convert.ToInt32(choice)){
                        case 1:  
                            int card = program.dealCard(isPlayer);
                            playerScore += card;
                            break;
                        case 2:
                            break;
                        case 3:
                            winner = "dealer";
                            isOver = true;
                            break;
                        default:
                            isPlayer = !isPlayer;
                            Console.WriteLine("invalid option");
                            break;
                    }
                   
                } else{
                    if (dealerScore > 16){
                        Console.WriteLine($"The dealer stayed at {dealerScore}");
                        isOver = true;
                        if (dealerScore == playerScore){
                            winner = "No One";
                        }
                        else if (dealerScore > playerScore){
                            winner = "The dealer!";
                        } else{
                            winner = "you!";
                        }
                    } else{
                        int card = program.dealCard(isPlayer);
                        dealerScore += card;
                    }
                } 
                if (playerScore > 21){
                    isOver = true;
                    winner = "The dealer";
                }
                if (dealerScore > 21){
                    isOver = true;
                    winner = "You";
                }

                isPlayer = !isPlayer;

            }
            Console.WriteLine($"The Winner is {winner}!");
        }

        public int dealCard(bool isPlayer){
            String currPlayer = isPlayer ? "You " : "The Dealer"; 
            Random ran = new Random();
            int randomNumber = ran.Next(1,10);
            Cards selectedCard = (Cards)(randomNumber - 1);
            Console.WriteLine($"{currPlayer} drew a {selectedCard}");
            return randomNumber;
        }

        public enum Cards{
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten
        }
    }
}
