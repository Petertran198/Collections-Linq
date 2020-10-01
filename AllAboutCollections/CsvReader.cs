using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AllAboutCollections
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }
        // Pratice using an array
        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            // Used to read text files requires a path to file that the StreamReader will read
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //Read the header line in excel
                sr.ReadLine();
                for (int i = 0; i < nCountries; i++){
                    string csvLine = sr.ReadLine();
                    // Holds an object containing info about each country it parse 
                    countries[i] = ReadCountryFromCsvLine(csvLine);
                }
            }
            return countries;
        }
        //Pratice using a List
        public List<Country> ReadAllCountry()
        {
            List<Country> countries = new List<Country>();

            // Used to read text files requires a path to file that the StreamReader will read
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //Read the header line in excel
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    string csvLine = sr.ReadLine();
                    // Holds an object containing info about each country it parse 
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }
            return countries;
        }

        //Pratice using a dictionary
        public Dictionary<string, Country> ReadAllCountryDictionary()
        {
            var countries = new Dictionary<string, Country>();

            // Used to read text files requires a path to file that the StreamReader will read
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //Read the header line in excel
                sr.ReadLine();
                string csvLine;

                while (!sr.EndOfStream)
                {
                    csvLine = sr.ReadLine();
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);

                }
            }
            return countries;
        }

        //Takes in a single line from csv file and covert it into country
        public Country ReadCountryFromCsvLine(string csvline)
        {
            string[] parts = csvline.Split(",");
            string name;
            string code;
            string region;
            string populationText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    populationText = parts[3];
                    break;
                case 5:
                    name = $"{parts[0]}, {parts[1]}";
                    code = parts[2];
                    region = parts[3];
                    populationText = parts[4];
                    break;
                default:
                    throw new Exception("Can not split parse ");
            }
            int.TryParse(populationText, out int population);
            return new Country(name, code, region, population);

        }



    }
}
