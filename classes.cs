using System;
using System.Collections.Generic;
using System.IO;

//start of space class
public abstract class Space
{
    public string Name;
    public string Type;
    public int position;
    public Space(string givenName, string givenType, int givenPosition){
        Name = givenName;
        Type = givenType;
        position = givenPosition;
    }
    public Space(){
        Console.WriteLine("Called the wrong Space Constructor.");
    }
}

public class Property : Space
{
    //player enum to store player pieces names
    public enum PlayerPieces
    {
        Dog = 1, Cat = 2, TopHat = 3, Battleship = 4, Shoe = 5, Wheelbarrow = 6, Thimble = 7, Iron = 8

    }
    protected int Rent;
    protected int price;
   // removed because it's calculatable
   // int mortgagePrice;
    protected bool owned;
    protected int owner;
    protected string color;
    // start of property functions
    public virtual void calculaterent()
    {
        //rent typically is only rent
        Rent = Rent;
    }
    public virtual void updateOwner(int givenInt)
    {
        //transfers ownership to other player
        owner = givenInt;
    }
    public Property(int givenRent, int givenPrice, bool givenOwned, int givenOwner, string givenColor,
    string givenName, string givenType, int givenPosition): base(givenName, givenType, givenPosition){
        Rent = givenRent;
        price = givenPrice;
        owned = givenOwned;
        owner = givenOwner;
        color = givenColor;
        //DEBUG
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", Rent, price, owned, owner, Name, Type, position, color);
    }
    public Property(){
        Console.WriteLine("Called the wrong Property Constructor.");
    }
}
//start of resedential property class
public class Resedential : Property
{
    int rent2Houses;
    int rent3Houses;
    int rentHotel;
    //functions for resedential properties
    public override void calculaterent()
    {
        if(rent2Houses == 1){
            Rent *= 2;
        }else if(rent3Houses == 1){
            Rent *= 3;
        }else if(rentHotel == 1){
            Rent *= 4;
        }
    }
    public override void updateOwner(int givenInt)
    {

    }
}
//end of resedential property class
//start of utility property class
public class Utility : Property
{
    bool rentDualUtility;
    int RentDualUtility;
    //utility class functions
    public override void calculaterent()
    {
        if(rentDualUtility == true){
            Rent = Rent + (10 * RentDualUtility);
        }
    }
    public override void updateOwner(int givenInt)
    {
        owner = givenInt;
    }
    public Utility(bool givenRentDualUtility, int givenRentNumber,int givenRent, int givenPrice, bool givenOwned, int givenOwner, string givenColor,
    string givenName, string givenType, int givenPosition):
    base(givenRent,givenPrice,givenOwned,givenOwner, givenColor,
    givenName,givenType,givenPosition){
        rentDualUtility = givenRentDualUtility;
        RentDualUtility = givenRentNumber;
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", Name, Type, position, color, owned, owner, price, Rent, rentDualUtility, RentDualUtility);
    }

    public Utility(){
        Console.WriteLine("Blank Utility Constructor");
    }
}
//end of utility property class
//start of otherSpace
public class otherSpace : Space
{
    string action;
    //functions for otherSpace
    public void performAction()
    {
        if(action == "Draw Community Chest Card"){
            //Draws a random community chest card
        }else if (action == "Pay Income Tax"){
            //pay Income Tax
        }
    }
    public otherSpace(string givenAction, string givenName, string givenType, int givenPosition)
    :base(givenName, givenType, givenPosition){
        action = givenAction;
        Name = givenName;
        Type = givenType;
        position = givenPosition;
        //DEBUG
        Console.WriteLine("{0}, {1}, {2}, {3}", action, Name, Type, position);
    }
}
public class Player
{
    string Name;
    int playerPiece;
    int plyrPosition;
    int plyrMoney;
    List<string> PropertiesOwned = new List <string> ();
    bool jailed;
    //player functions
    public void addPlayer(int givenNum)
    {
        Console.WriteLine("NAME: ");
        Name = Console.ReadLine();
        plyrPosition = 1;
        playerPiece = givenNum++;
        jailed = false;
        //subject to change for balance
        plyrMoney = 2000;
    }
    public void updatePlayer()
    {

    }
    public void RollDice()
    {
        Random rnd = new Random();
        int dice = rnd.Next(1, 7);
        plyrPosition += dice;
        if(plyrPosition >= 41){
            plyrPosition -= 40;
        }
    }
    public void PayRent(int rentCharge)
    {
        plyrMoney -= rentCharge;
    }
    public void BuySpace(string SpaceName, int PriceAmount)
    {
        PropertiesOwned.Add(SpaceName);
        plyrMoney -= PriceAmount;
    }
    public void DrawCard()
    {

    }
    public void Mortgage( int MortgageAmount, string SpaceName)
    {
        plyrMoney += MortgageAmount;
        PropertiesOwned.Remove(SpaceName);
    }
    public void BuyHouse()
    {
        //subject to change
        plyrMoney -= 100;
    }
    public void BuyHotel()
    {
        //subject to change
        plyrMoney -= 200;
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
    public void ChargePlayer(int Amount)
    {
        Money += Amount;
    }
    public void PayPlayer(int Amount)
    {
        Money -= Amount;
    }
}
public class Dice
{
    int NumberDice;
    int NumberOnDice;
}
