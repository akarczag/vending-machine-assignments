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

            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Welcome to the C# Vending Machine");
            Console.WriteLine("=================================");
            Console.WriteLine("===Today's Soda Price is $.025===");
            Console.WriteLine("=================================");
            Console.WriteLine();

            bool exitVend = false;
            do
            {
                decimal totalValueInserted = 0M;
                while (totalValueInserted < sodaPrice.PriceDecimal)
                {
                    bool checkValue = false;
                    if(totalValueInserted == sodaPrice.PriceDecimal)
                    {
                        checkValue = true;
                    }

                    if (checkValue == false)
                    {
                        Console.Write("Please insert coins one at a time: ");
                        Console.WriteLine();

                        string coinNameInserted = Console.ReadLine().ToUpper();
                        Coin coinInserted = new Coin(coinNameInserted);

                        Console.WriteLine("You have inserted a {0} worth {1:c}", coinInserted, coinInserted.ValueOf);
                        Console.WriteLine();

                        totalValueInserted += coinInserted.ValueOf;
                        Console.WriteLine("Total value inserted is {0:c}", totalValueInserted);
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("Thanks, you have now inserted {0:c}", totalValueInserted);
                Console.WriteLine();
                Console.WriteLine($"Please choose your flavor: {showFlavors.DisplayCanRackString()}");
                Console.WriteLine();

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
                            Console.WriteLine();
                    }
                    else
                        {
                            Console.WriteLine($"Sorry, there is no more {chosenFlavor} flavor soda.");
                            Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, {chosenFlavor} is not an available flavor.");
                    Console.WriteLine();
                }

                Console.WriteLine("Would you like to exit the vending machine? (y/n)");
                Console.WriteLine();

                string response = Console.ReadLine();
                
                if (response == "y")
                {
                    exitVend = true;
                }
            } while (exitVend == false);
        }
    }
}
