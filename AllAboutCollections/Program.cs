using System;
using System.Collections.Generic;

namespace AllAboutCollections
{
    class Program
    {
        static void Main(string[] args)
        {

			//string filePath = @"C:\Users\peter\source\repos\AllAboutCollections\AllAboutCollections\arr.csv";
			//CsvReader reader = new CsvReader(filePath);

			///*Country[] countries = reader.ReadFirstNCountries(3);*/
			//List<Country> countries = reader.ReadAllCountry();

			//foreach (Country country in countries) 
			//{
			//	Console.WriteLine($"{country.Population.ToString("N0")}| {country.Name}  {country.Code}");
			//}

			string filePath = @"C:\Users\peter\source\repos\AllAboutCollections\AllAboutCollections\arr.csv";
			CsvReader reader = new CsvReader(filePath);
			var countries = reader.ReadAllCountryDictionary();

			Console.WriteLine("Enter is the  country you are looking for");
			var answer = Console.ReadLine();
			bool doesExist = countries.TryGetValue(answer, out var countryObj);
			Console.WriteLine($"The country {countryObj.Name}");

			while (doesExist)
            {
				Console.WriteLine("Enter is the  country you are looking for");
				var answer2=  Console.ReadLine();
				bool isReal = countries.TryGetValue(answer2, out var country);
                if (isReal)
                {
					Console.WriteLine($"The country {country.Name}");

                }
                else
                {
					doesExist = false;
					Console.WriteLine($"Invalid Country..");

				}


			}

		}
			
    }
}
