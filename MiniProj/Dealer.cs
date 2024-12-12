namespace MiniProj;
public class Dealer {
    /*
    Dealer class responsible for controlling the dealing of cards. Uses enum to have a set list of cards to draw from.
    DealCard method takes in which turn is being dealt for and selects a random value from 1-11 inclusive. 
    returns am integer. 
    */
    public enum Cards{
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        ELEVEN
    }
    public static int DealCard(bool isPlayer){
        string currPlayer = isPlayer ? "YOU" : "The DEALER"; 
        Random ran = new();
        int randomNumber = ran.Next(0,11);
        Cards selectedCard = (Cards)randomNumber;
        Console.WriteLine($"{currPlayer} drew a {selectedCard}");
        return randomNumber;
    }
}
