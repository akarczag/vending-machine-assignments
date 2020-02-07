using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_4._2_Coins
{
    class DisplayRack
    {
        // This method displays all of the flavor names to the user (as strings only)
        public string DisplayCanRackString()
        {
            string Flavors = ConvertStringArrayToString(flavorNames);
            string FlavorsJoined = ConvertStringArrayToStringJoin(flavorNames);
            return FlavorsJoined;
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
                builder.Append(',');
            }
            return builder.ToString();
        }

        // This method joins my strings together into a readable list 
        static string ConvertStringArrayToStringJoin(string[] flavorNames)
        {
            // Use string Join to concatenate the string elements.
            string result = string.Join(", ", flavorNames);
            return result;
        }
    }
}
