using System;

//start of space class
public class Space
{
    string Name;
    string Type;
    int position;
}

public class Property : Space
{
    //player enum to store player pieces names
    public enum PlayerPieces
    {
        Dog = 1, Cat = 2, TopHat = 3, Battleship = 4, Shoe = 5, Wheelbarrow = 6, Thimble = 7, Iron = 8

    }
    int Rent;
    int price;
    int mortgagePrice;
    bool owned;
    int owner;
    int numHouses;
    int numHotels;
    // start of property functions
    public virtual int calculaterent()
    {
        if(numHouses >= 1){
            //if there are houses, it's half of the rent times the number of houses. Subject to change
            Rent = (Rent * numHouses) / 2;
        }else if(numHotels == 1){
            //if there is a hotel, the rent is tripled
            Rent = Rent * 3;
        }
        Return Rent;
    }
    public virtual void updateOwner()
    {
        owner = PlayerPieces;
    }
    //constructor
    public Property(givenName, givenType, givenPosition, givenRent, givenPrice, givenHouses, givenHotels, givenOwner){
        Name = givenName;
        Type = givenType;
        position = givenPosition;
        Rent = givenRent;
        price = givenPrice;
        numHouses = givenHouses;
        numHotels = givenHotels;
        owner = givenOwner;
    }
}
//start of utility property class
public class Utility : Property
{
    bool rentDualUtility;
    int RentDualUtility;
    //utility class functions
    public override int calculaterent(givenNumber)
    {
        //if you have one utility it is 16, 2 is 26, etc.
        Rent = Rent + (10*givenNumber)
        return Rent;
    }
    public override void updateOwner()
    {
        owner = PlayerPieces;
    }
}
//end of utility property class
//start of otherSpace
public class otherSpace : Space
{
    string action;
    //functions for otherSpace
    public void performAction(player)
    {
        if(name == 'Go'){
            player.plyrMoney += 200;
        }else if (name == 'Community Chest'){
            console.log('Draw a random community Chest card')
        }//etc.
    }
}
public class Player
{
    string Name;
    int playerPiece;
    int plyrPosition;
    int plyrMoney;
    string[] PropertiesOwned = new string[] { };
    bool jailed;
    int position;
    //player functions
    public void addPlayer(givenName, givenPiece)
    {
        Name = givenName;
        playerPiece = givenPiece;
        //subject to change
        plyrMoney = 1000;
        position = 1;
        jailed = false;
        Console.log("Player successfully added.")
    }
    public void updatePlayer()
    {

    }
    public void RollDice()
    {
        Random dice = new Random();
        int roll = dice.next(1, 7)
        plyrPosition += roll;
        //roll over to go through the board again
        if(plyrPosition >= 40){
            plyrPosition -= 40;
        }
        Console.log("The new position is: {0}", plyrPosition)
    }
    public void PayRent()
    {
        plyrMoney -= rent;
    }
    public void BuySpace()
    {
        plyrMoney -= price;
    }
    public void Mortgage()
    {

    }
    public void BuyHouse()
    {
        plyrMoney -= 50;
        numHouses++;
    }
    public void BuyHotel()
    {
        plyrMoney -= 200;
        numHotels++;
    }
    //end of player functions
}
public class Bank
{
    int Money;
    int numberRemainingHouses;
    //only 32 houses allowed
    int numberRemaingHotels;
    //only 12 hotels allowed
    //Bank Functions
    public void ChargePlayer()
    {
        
    }
    public void PayPlayer()
    {

    }
}
