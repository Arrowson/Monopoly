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
    // start of property functions
    public virtual void calculaterent()
    {

    }
    public virtual void updateOwner()
    {

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

    }
    public override void updateOwner()
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

    }
    public override void updateOwner()
    {

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
    public void addPlayer()
    {

    }
    public void updatePlayer()
    {

    }
    public void RollDice()
    {

    }
    public void PayRent()
    {

    }
    public void BuySpace()
    {

    }
    public void DrawCard()
    {

    }
    public void Mortgage()
    {

    }
    public void BuyHouse()
    {

    }
    public void BuyHotel()
    {

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
public class Dice
{
    int NumberDice;
    int NumberOnDice;
}
