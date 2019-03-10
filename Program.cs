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
            // Does the full company name key already exist in the `stockReport`?
            // If it does, update the total valuation
            if (stockReport.ContainsKey(stocks[kvp.Key])) {
              stockReport[stocks[kvp.Key]] += kvp.Value;
            /*
                If not, add the new key and set its value.
                You have the value of "GM", so how can you look
                the value of "GM" in the `stocks` dictionary
                to get the value of "General Motors"?
             */
            } else {
              stockReport.Add(stocks[kvp.Key], kvp.Value);
            }
          }
            foreach (KeyValuePair<string, double> item in stockReport) {
              Console.WriteLine($"The position in {item.Key} is worth {item.Value}");
            }
          /* 
            The position in General Motors is worth 230.21
            The position in General Motors is worth 811.19
            The position in General Motors is worth 1217.53
            The position in General Motors is worth 1217.53
            The position in Caterpillar is worth 100.21
            The position in General Motors is worth 1217.53
            The position in Caterpillar is worth 560.54
            The position in General Motors is worth 1217.53
            The position in Caterpillar is worth 560.54
            The position in Dow Jones is worth 508.9
            The position in General Motors is worth 1217.53
            The position in Caterpillar is worth 560.54
            The position in Dow Jones is worth 1209.88
          */
        }
      }
    }
  }
}
