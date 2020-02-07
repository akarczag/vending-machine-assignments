// Karczag, Ash
// kickash@uw.edu

using System;

namespace Ex_4._2_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchasePrice sodaPrice = new PurchasePrice(0.25M);
            CanRack sodaRack = new CanRack();
            DisplayRack showFlavors = new DisplayRack();

            Console.WriteLine("=================================");
            Console.WriteLine("Welcome to the C# Vending Machine");
            Console.WriteLine("=================================");

            bool exitVend = false;
            do
            {
                Console.Write("Please insert {0:c} worth of coins: ", sodaPrice.PriceDecimal);

                decimal totalValueInserted = 0M;
                while (totalValueInserted < sodaPrice.PriceDecimal)
                {
                    string coinNameInserted = Console.ReadLine();
                    Coin coinInserted = new Coin(coinNameInserted);

                    Console.WriteLine("You have inserted a {0} worth {1:c}", coinInserted, coinInserted.ValueOf);

                    totalValueInserted += coinInserted.ValueOf;
                    Console.WriteLine("Total value inserted is {0:c}", totalValueInserted);

                    //the steps below are intended to allow the user to insert more money
                    //it's not currently working, and it prevents the correct amount from working
                    //so it's commented out for now 

                    Console.WriteLine("Please insert more money: ");

                    string moreValue = Console.ReadLine().ToUpper();

                    Coin moreMoney = new Coin(moreValue);
                    //decimal theMoney = Convert.ToDecimal(moreValue);

                    totalValueInserted += moreMoney.ValueOf;
                }

                Console.WriteLine("You have inserted {0:c}", totalValueInserted);
                Console.WriteLine($"Please choose your flavor: {showFlavors.DisplayCanRackString()}");

                string choseFlavor = Console.ReadLine();
                string chosenFlavor = choseFlavor.ToUpper();

                string[] flavorChoice = Enum.GetNames(typeof(Flavor));
                bool isFlavorName = false;
                foreach (string flavorName in flavorChoice)
                {
                    if (flavorName.Equals(chosenFlavor)) isFlavorName = true;
                }

                if (isFlavorName == true)
                {
                        bool checkRack = sodaRack.IsEmpty(chosenFlavor);
                        if (checkRack == false)
                        {
                            sodaRack.RemoveACanOf(chosenFlavor);
                            Console.WriteLine($"Thanks, here is your {chosenFlavor} soda.");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, there is no more {chosenFlavor} flavor soda.");
                        }
                }
                else
                {
                    Console.WriteLine($"Sorry, {chosenFlavor} is not an available flavor.");
                }

                Console.WriteLine("Would you like to exit the vending machine? (y/n)");
                string response = Console.ReadLine();
                
                if (response == "y")
                {
                    exitVend = true;
                }
            } while (exitVend == false);
        }
    }
}
