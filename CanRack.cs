// Karczag, Ash
// kickash@uw.edu
using System;
using System.Diagnostics;
using System.Text;

namespace Ex_4._2_Coins
{
    public class CanRack
    {
        private int[] rack = new int[Enum.GetValues(typeof(Flavor)).Length];
      
        private const int EMPTYBIN = 0;
        private const int BINSIZE = 3;

        // Constructor for a can rack. The rack starts out full
        public CanRack()
        {
            FillTheCanRack();
        }

        //get all the flavor names for later
        public static string[] flavorNames = Enum.GetNames(typeof(Flavor));

        // This method converts my string array into a string to display the flavor names to the user
        static string ConvertStringArrayToString(string[] flavorNames)
        {
            // Concatenate all the elements into a StringBuilder.
           StringBuilder builder = new StringBuilder();
           foreach (string value in flavorNames)
           {
               builder.Append(value);
               builder.Append('.');
           }
           return builder.ToString();
        }

        // This method joins my strings together into a readable list 
        static string ConvertStringArrayToStringJoin(string[] flavorNames)
        {
            // Use string Join to concatenate the string elements.
            string result = string.Join(".", flavorNames);
            return result;
        }

        //  This method adds a can of the specified flavor to the rack.  
        public void AddACanOf(string FlavorOfCanToBeAdded)
        {
            // this checks to make sure that the flavor to be added is an actual flavor
            string[] flavorNames = Enum.GetNames(typeof(Flavor));
            bool isFlavorName = false;
            foreach (string flavorName in flavorNames)
            {
                if (flavorName.Equals(FlavorOfCanToBeAdded)) isFlavorName = true;
            }

            FlavorOfCanToBeAdded = FlavorOfCanToBeAdded.ToUpper();
            if (IsFull(FlavorOfCanToBeAdded) && isFlavorName == true)
            {
                Console.WriteLine($"Sorry, {FlavorOfCanToBeAdded} could not be added to the rack because the rack is already full.");
            }
            else if (isFlavorName == false)
            {
                Console.WriteLine($"Sorry, but {FlavorOfCanToBeAdded} is not a recognized flavor.");
            }
            else
            {
                Console.WriteLine($"Adding a can of {FlavorOfCanToBeAdded} flavored soda to the rack.");

                if (Enum.IsDefined(typeof(Flavor), FlavorOfCanToBeAdded))
                {
                    Flavor flavorInt = (Flavor)Enum.Parse(typeof(Flavor), FlavorOfCanToBeAdded);
                    int flavorCount = (int)flavorInt;
                    rack[flavorCount]++;
                }
                
                else Debug.WriteLine($"Error: attempt to add a can of unknown flavor {FlavorOfCanToBeAdded}. Flavor is unknown.");
            }
        }

        public void AddACanOf(Flavor FlavorOfCanToBeAdded)
        {
            AddACanOf(FlavorOfCanToBeAdded.ToString());
        }

        //  This method will remove a can of the specified flavor from the rack.
        public void RemoveACanOf(string FlavorOfCanToBeRemoved)
        {
            // this checks to make sure that the flavor to be removed is an actual flavor
            string[] flavorNames = Enum.GetNames(typeof(Flavor));
            bool isFlavorName = false;
            foreach(string flavorName in flavorNames)
            {
                if (flavorName.Equals(FlavorOfCanToBeRemoved)) isFlavorName = true;
            }

            FlavorOfCanToBeRemoved = FlavorOfCanToBeRemoved.ToUpper();
            if (IsEmpty(FlavorOfCanToBeRemoved) && isFlavorName == true)
            {
                Console.WriteLine($"Sorry, {FlavorOfCanToBeRemoved} could not be removed from the rack because the rack is empty.");
            }
            else if (isFlavorName == false)
            {
                Console.WriteLine($"Sorry, but {FlavorOfCanToBeRemoved} is not a recognized flavor.");
            }
            else
            {
                if (Enum.IsDefined(typeof(Flavor), FlavorOfCanToBeRemoved))
                {
                    Console.WriteLine($"Removing a can of {FlavorOfCanToBeRemoved} flavored soda from the rack");
                    Flavor flavorInt = (Flavor)Enum.Parse(typeof(Flavor), FlavorOfCanToBeRemoved);
                    int flavorCount = (int)flavorInt;
                    rack[flavorCount]--;
                }
                else Debug.WriteLine($"Error: attempt to add a can of unknown flavor {FlavorOfCanToBeRemoved}. Flavor is unknown.");
            }
        }

        public void RemoveACanOf(Flavor FlavorOfCanToBeRemoved)
        {
            RemoveACanOf(FlavorOfCanToBeRemoved.ToString());
        }

        //  This method will fill the can rack
        public void FillTheCanRack()
        {
            Debug.WriteLine("Filling the can rack...");
            
            foreach (int flavorInt in Enum.GetValues(typeof(Flavor)))
            {
                rack[flavorInt] = BINSIZE;
            }

        }

        //  This public void will empty the rack of a given flavor.
        public void EmptyCanRackOf(string FlavorOfBinToBeEmptied)
        {
            FlavorOfBinToBeEmptied = FlavorOfBinToBeEmptied.ToUpper();
            
            if (Enum.IsDefined(typeof(Flavor), FlavorOfBinToBeEmptied))
            {
                Debug.WriteLine($"Emptying can rack of flavor {FlavorOfBinToBeEmptied}");

                Flavor emptyFlavor = (Flavor)Enum.Parse(typeof(Flavor), FlavorOfBinToBeEmptied);
                rack[(int)emptyFlavor] = EMPTYBIN;
            }
            else
            {
                Debug.WriteLine($"Sorry, could not empty bin of {FlavorOfBinToBeEmptied} because it is not a recognized flavor.");
            }
        }

        public void EmptyCanRackOf(Flavor FlavorOfBinToBeEmptied)
        {
            EmptyCanRackOf(FlavorOfBinToBeEmptied.ToString());
        }

        public Boolean IsFull(string FlavorOfBinToBeChecked)
        {
            FlavorOfBinToBeChecked = FlavorOfBinToBeChecked.ToUpper();
            Boolean result = false;
            Debug.WriteLine($"Checking if can rack is full of flavor {FlavorOfBinToBeChecked}");
            // convert the string Flavor into the appropriate int value
            Flavor flavorEnumeral;
            if (Enum.IsDefined(typeof(Flavor), FlavorOfBinToBeChecked))
            {
                flavorEnumeral = (Flavor)Enum.Parse(typeof(Flavor), FlavorOfBinToBeChecked);
                int flavorIndex = (int)flavorEnumeral;
                result = rack[flavorIndex] == BINSIZE;
            }
            else
            {
                Debug.WriteLine($"Error: attempt to check rack status of unknown flavor {FlavorOfBinToBeChecked}");
            }
            return result;
        }

        public Boolean IsFull(Flavor FlavorOfBinToBeChecked)
        {
            return IsFull(FlavorOfBinToBeChecked.ToString());
        }

        public Boolean IsEmpty(string FlavorOfBinToBeChecked)
        {
            FlavorOfBinToBeChecked = FlavorOfBinToBeChecked.ToUpper();
            bool result = false;
            Debug.WriteLine("Checking if can rack is empty of flavor {0}", FlavorOfBinToBeChecked);
            // convert the string Flavor into the appropriate int value
            Flavor flavorEnumeral;
            if (Enum.IsDefined(typeof(Flavor), FlavorOfBinToBeChecked))
            {
                flavorEnumeral = (Flavor)Enum.Parse(typeof(Flavor), FlavorOfBinToBeChecked);
                int flavorIndex = (int)flavorEnumeral;
                result = rack[flavorIndex] == EMPTYBIN;
            }
            else
            {
                Debug.WriteLine($"Error: attempt to check rack status of unknown flavor {FlavorOfBinToBeChecked}");
            }
            return result;
        }

        public Boolean IsEmpty(Flavor FlavorOfBinToBeChecked)
        {
            return IsEmpty(FlavorOfBinToBeChecked.ToString());
        }

        // This method displays all of the flavor names to the user (as strings only)
        public string DisplayCanRackString() {
            string Flavors = ConvertStringArrayToString(flavorNames);
            string FlavorsJoined = ConvertStringArrayToStringJoin(flavorNames);
            return FlavorsJoined;
        }

        public void DisplayCanRack()
        {
            Console.WriteLine("This vending machine contains the following soda flavors:");
            Console.WriteLine("=========================================================");
            foreach(string flavorName in Enum.GetNames(typeof(Flavor)))
            {
                Flavor flavorNumber = (Flavor)Enum.Parse(typeof(Flavor), flavorName);
                int flavorNum = (int)flavorNumber;

                Console.WriteLine($"{flavorNum}. {flavorName}");
            }
            Console.WriteLine("=========================================================");
        }

    } //end Can_Rack

}
