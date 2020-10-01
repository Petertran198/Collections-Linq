using System;
using System.Collections.Generic;

namespace AllAboutCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\peter\source\repos\AllAboutCollections\AllAboutCollections\arr.csv";
            CsvReader reader = new CsvReader(filePath);

            /*Country[] countries = reader.ReadFirstNCountries(3);*/
            List<Country> countries = reader.ReadAllCountry();
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
            for(int i = 0; i < countries.Count; i++)
            {
                // Will pause the number if it is more than one AND when the specified length is reached
                // aka if u enter 5, it will loop 5 times and 5%5 == 0 which is true and it will ask user if you want to continue
                if (i > 0 && (i % maxLength ==0) )
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
                Console.WriteLine($"{country.Population.ToString("N0").PadLeft(15)}| {country.Name}  {country.Code}");
            }


            //------------------------------ Pratice using tryParse --------------------------------------------------------
            //string filePath = @"C:\Users\peter\source\repos\AllAboutCollections\AllAboutCollections\arr.csv";
            //CsvReader reader = new CsvReader(filePath);
            //var countries = reader.ReadAllCountryDictionary();

            //Console.WriteLine("Enter is the  country you are looking for");
            //var answer = Console.ReadLine();
            //bool doesExist = countries.TryGetValue(answer, out var countryObj);
            //Console.WriteLine($"The country {countryObj.Name}");

            //while (doesExist)
            //         {
            //	Console.WriteLine("Enter is the  country you are looking for");
            //	var answer2=  Console.ReadLine();
            //	bool isReal = countries.TryGetValue(answer2, out var country);
            //             if (isReal)
            //             {
            //		Console.WriteLine($"The country {country.Name}");

            //             }
            //             else
            //             {
            //		doesExist = false;
            //		Console.WriteLine($"Invalid Country..");

            //	}


            //}

        }
			
    }
}
