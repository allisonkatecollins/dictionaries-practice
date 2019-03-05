using System;
using System.Collections.Generic;

namespace dictionaries_practice
{
  class Program
  {
    static void Main(string[] args)
    {
      Dictionary<string, string> stocks = new Dictionary<string, string>();
      stocks.Add("GM", "General Motors");
      stocks.Add("CAT", "Caterpillar");
      stocks.Add("DOW", "Dow Jones");

      //To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups.
      //stocks["GM"];   <--- "General Motors"

      //Next, create a list to hold stock purchases by an investor.
      List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>>();

      //purchases is a list containing multiple dictionaries
      purchases.Add(new Dictionary<string, double>() { { "GM", 230.21 } });
      purchases.Add(new Dictionary<string, double>() { { "GM", 580.98 } });
      purchases.Add(new Dictionary<string, double>() { { "GM", 406.34 } });
      purchases.Add(new Dictionary<string, double>() { { "CAT", 100.21 } });
      purchases.Add(new Dictionary<string, double>() { { "CAT", 460.33 } });
      purchases.Add(new Dictionary<string, double>() { { "DOW", 508.90 } });
      purchases.Add(new Dictionary<string, double>() { { "DOW", 700.98 } });

      //Create a total ownership report that computes the total value of each stock that you have purchased.
      //This is the basic relational database join algorithm between two tables.

      /*
        Define a new Dictionary to hold the aggregated purchase information.
        - The key should be a string that is the full company name.
        - The value will be the total valuation of each stock
        - i.e. <key, value> --> <string, double>
    */

      //stockReport is a dictionary starting with no values
      Dictionary<string, double> stockReport = new Dictionary<string, double>();

      /*
        Iterate over the purchases and record the valuation
        for each stock.
      */

      //every dictionary contains one key value pair and represents a single purchase
      foreach (Dictionary<string, double> purchase in purchases) {
        {
          //replace "stock" from instructions with "kvp" for clarity
          foreach (KeyValuePair<string, double> kvp in purchase)
          {
            Console.WriteLine($"kvp: {kvp}");

            //check if the new dictionary, stockReport, contains the key for each stock
            //as it exists within the "purchases" dictionary

            //exclamation mark means "if stockReport does NOT contain the key..."
             if (! stockReport.ContainsKey(kvp.Key)) {

              //add the KVP from stock dictionary as it exists within purchases list
              //stockReport is starting with no items
              stockReport.Add(kvp.Key, kvp.Value);
            } else {

              //access current value
              double currentCost = stockReport[kvp.Key];

              //update stockReport with new value --> add to current value
              //operates right to left
              stockReport[kvp.Key] = currentCost + kvp.Value;
            }

            foreach(KeyValuePair<string, double> item in stockReport)
            {
            Console.WriteLine($"The position in {item.Key} is worth {item.Value}");
            }

            // Does the full company name key already exist in the `stockReport`?
            
            // If it does, update the total valuation

            /*
                If not, add the new key and set its value.
                You have the value of "GM", so how can you look
                the value of "GM" in the `stocks` dictionary
                to get the value of "General Motors"?
            */
     
          }
        }
      }
    }
   /*  static void Planets(string[] args) {

    } */
  }
}
