using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Country> countries = GetCountryList(@"C:\\Users\\peter\\source\\repos\\AllAboutCollections\\AllAboutCollections\arr.csv");
            var filteredCountires = from country in countries 
                                    where !country.Name.Contains(",")
                                    select country; 

            foreach (var country in filteredCountires)
            {
                Console.WriteLine(country.Name);
            }
        }




        // Parse through the csv file and get a list of all countries 
        public static List<Country> GetCountryList(string file)
        {
            string filePath = file;
            CsvReader reader = new CsvReader(filePath);
            /*Country[] countries = reader.ReadFirstNCountries(3);*/

            List<Country> countries = reader.ReadAllCountry();
            return countries;
        }

        public static void ReadCountriesFromStart()
        {
            List<Country> countries = GetCountryList(@"C:\Users\peter\source\repos\AllAboutCollections\AllAboutCollections\arr.csv");
            

            Console.WriteLine("Enter number of countries to display at a time");
            string userInputString = Console.ReadLine();
            // TryParse returns a boolean , if it is true userInput will contain the valid int and we can go on normally 
            bool isInputInt = int.TryParse(userInputString, out int userInput);
            if (!isInputInt || userInput <= 0)
            {
                Console.WriteLine("Not a valid number");
            }

            // Get how much numbers you want to display at a time 
            int maxLength = userInput;
            for (int i = 0; i < countries.Count; i++)
            {
                // Will pause the number if it is more than one AND when the specified length is reached
                // aka if u enter 5, it will loop 5 times and 5%5 == 0 which is true and it will ask user if you want to continue
                if (i > 0 && (i % maxLength == 0))
                {
                    Console.WriteLine("Press q to exist");

                    string quit = "q";
                    string answer = Console.ReadLine().ToLower();
                    if (quit == answer)
                    {
                        break;
                    }
                }
                Country country = countries[i];
                Console.WriteLine($"{i + 1}. {country.Population.ToString("N0").PadLeft(15)}| {country.Name}  {country.Code}");
            }
        }









        // Read data from the list starting from the end
        public static void ReadCountriesFromEnd()
        {
            List<Country> countries = Program.GetCountryList(@"C:\\Users\\peter\\source\\repos\\AllAboutCollections\\AllAboutCollections\arr.csv");
            Console.WriteLine("Enter number of countries to display at a time");
            string userInputString = Console.ReadLine();
            Console.WriteLine("------------------------------------");

            // TryParse returns a boolean , if it is true userInput will contain the valid int and we can go on normally 
            bool isInputInt = int.TryParse(userInputString, out int userInput);
            if (!isInputInt || userInput <= 0)
            {
                Console.WriteLine("Not a valid number");
            }


            // Get how much numbers you want to display at a time 
            int maxLength = userInput;
            for (int i = countries.Count - 1; i >= 0; i--)
            {

                int displayInfo = countries.Count - 1 - i;
                // Will pause the number if it is more than one AND when the specified length is reached
                // aka if u enter 5, it will loop 5 times and 5%5 == 0 which is true and it will ask user if you want to continue
                if (displayInfo > 0 && (displayInfo % maxLength == 0))
                {
                    Console.WriteLine("Press q to exist");

                    string quit = "q";
                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("------------------------------------");
                    if (quit == answer)
                    {
                        break;
                    }
                }
                Country country = countries[i];
                Console.WriteLine($"{displayInfo + 1}. {country.Population.ToString("N0").PadLeft(15)}| {country.Name}  {country.Code}");
            }
        }




    }
}
