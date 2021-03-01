using System;

namespace Valute_exchangerr
{
    class Program
    {
      
        static void Main(string[] args)
        {

            Valute valute = new Valute();

            
            do
            {
                valute.ReadFile();
                Console.WriteLine("_ _ _ _ _ CONVERTER _ _ _ _ _");
                Console.WriteLine("Select one of the 4 options:");
                Console.WriteLine("1.Add currency");
                Console.WriteLine("2.Edit currency");
                Console.WriteLine("3.Delete currrency");
                Console.WriteLine("4.Convert currency's");
                Console.WriteLine("5.View saved currency's");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    valute.CreateValue();
                }
                else if (input == "2")
                {
                    valute.EditCurrency();
                }
                else if (input == "3")
                {
                    valute.DeleteCurrency();
                }
                else if (input == "4")
                {
                    valute.Exchange();
                }
                else if (input == "5")
                {
                    valute.PrintsavedValutes();
                }
                
                
        
            } while (true);
            
       
            
           
          
            
        }
    }
}
