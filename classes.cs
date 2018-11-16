using System;
using System.Collections.Generic;
using System.IO;

//start of space class
public abstract class Space
{
    protected string Name;
    protected string Type;
    protected int position;
    public Space(string givenName, string givenType, int givenPosition){
        Name = givenName;
        Type = givenType;
        position = givenPosition;
    }
    public Space(string[] datas){
        Name = datas[1].Trim();
        Type = datas[2].Trim();
        position = int.Parse(datas[3].Trim());
    }
    public Space(string[] datas, string Util, string Prop){
        Name = datas[7].Trim();
        Type = datas[8].Trim();
        position = Convert.ToInt32(datas[9].Trim());
    }
    public Space(string[] datas, string Prop){
        Name = datas[5].Trim();
        Type = datas[6].Trim();
        position = Convert.ToInt32(datas[7].Trim());
    }
    public Space(){
        Console.WriteLine("Called the wrong Space Constructor");
    }
}

public class Property : Space
{
    //player enum to store player pieces names
    protected enum PlayerPieces
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
    public Property(string[] datas):base(datas){
        
    }
    public Property(string[] datas, string Util, string Prop):base(datas, Util, Prop){
        Rent = int.Parse(datas[2].Trim());
        price = Convert.ToInt32(datas[3].Trim());
        owned = bool.Parse(datas[4].Trim());
        owner = Convert.ToInt32(datas[5].Trim());
        color = datas[6].Trim();
    }
    public Property(string[] datas, string Prop):base(datas, Prop){
        Rent = int.Parse(datas[0].Trim());
        price = Convert.ToInt32(datas[1].Trim());
        owned = bool.Parse(datas[2].Trim());
        owner = Convert.ToInt32(datas[3].Trim());
        color = datas[4].Trim();
    }
    public Property(){
        Console.WriteLine("Called the Wrong Property Constructor");
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
    public Resedential(){
        Console.WriteLine("Called the Wrong Resedential Constructor");
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

    public Utility(string[] datas, string Util, string Prop):base(datas, Util, Prop){
        rentDualUtility = bool.Parse(datas[0].Trim());
        //Console.WriteLine(datas[0].Trim());
        RentDualUtility = Convert.ToInt32(datas[1].Trim());
        //Console.WriteLine(datas[1].Trim());
    }
}
//end of utility property class
//start of otherSpace
public class otherSpace : Space
{
    string action;
    //functions for otherSpace
    public void performAction(Player player)
    {
        switch (action){

            case "200":
                player.CompleteTask("200");
                break;
            case "Community":
                Random CardDrawn = new Random();
                
                break;
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
    public otherSpace(string[] datas):base(datas){
        action = datas[0].Trim();
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
    public void CompleteTask(string task)
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
