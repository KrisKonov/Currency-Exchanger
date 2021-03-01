using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Valute_exchangerr
{
    class Valute
    {


        ValuteInfo create = new ValuteInfo();


        List<ValuteInfo> savedValues = new List<ValuteInfo>();



        public void CreateValue()
        {

            ValuteInfo valueDetails = new ValuteInfo();
            Console.WriteLine("Enter currency name");
            valueDetails.Name = Console.ReadLine();
            Console.WriteLine("Enter currency code");
            valueDetails.Code = Console.ReadLine();
            Console.WriteLine("Enter currency rate");
            valueDetails.Rate = Convert.ToDecimal(Console.ReadLine());
            savedValues.Add(valueDetails);
            WriteFile();
            Console.WriteLine("Currency added succesfuly!");

        }

        public void EditCurrency()

        {
            do
            {
                Console.WriteLine("1.Edit currency name");
                Console.WriteLine("2.Edit currency code");
                Console.WriteLine("3.Edit currency rate");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter currency name you want to edit");
                    string nameedit = Console.ReadLine();
                    bool isFound = false;

                    for (int i = 0; i < savedValues.Count; i++)
                    {
                        if (!isFound)
                            if (nameedit == savedValues[i].Name)
                            {
                                isFound = true;
                                Console.WriteLine("Enter the new name of the currency");
                                savedValues[i].Name = Console.ReadLine();
                                WriteFile();
                            }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("Currency doesn't exist");
                        Console.Clear();
                    }


                }
                else if (input == "2")
                {
                    bool IsFound = false;
                    Console.WriteLine("Enter the code of the currency you want to delete");
                    string code = Console.ReadLine();
                    for (int i = 0; i < savedValues.Count; i++)
                    {
                        if (!IsFound)
                        {
                            if (code == savedValues[i].Code)
                            {
                                Console.WriteLine("Enter the new code");
                                savedValues[i].Code = Console.ReadLine();
                                WriteFile();

                            }
                        }
                    }
                    if (!IsFound)
                    {
                        Console.WriteLine("Currency doesn't exist");
                        Console.Clear();
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter the currency which you want to change the rate of:");
                    decimal rate = decimal.Parse(Console.ReadLine());
                    bool isFind = false;
                    for (int i = 0; i < savedValues.Count; i++)
                    {
                        if (!isFind)
                        {
                            if (rate == savedValues[i].Rate)
                            {
                                isFind = true;
                                Console.WriteLine("Enter the new currency");
                                savedValues[i].Rate = decimal.Parse(Console.ReadLine());
                                WriteFile();
                            }
                        }
                    }
                    if (!isFind)
                    {
                        
                        Console.WriteLine("Currency doesn't exist");
                      
                        
                    }
                }
            
            } while (false);

        }


        public void WriteFile()
        {
            using (StreamWriter sw = new StreamWriter("Valuedata.txt"))
            {
                for (int b = 0; b < savedValues.Count; b++)
                {
                    sw.WriteLine(savedValues[b].Name + ";" + savedValues[b].Code + ";" + savedValues[b].Rate);

                }
            }
        }

        public void ReadFile()
        {
            try
            {
                using (var sr = new StreamReader(@"Valuedata.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var parts = line.Split(";");
                        if (parts.Length == 3)
                        {
                            savedValues.Add(new ValuteInfo(){ Name = parts[0], Code = parts[1], Rate = Convert.ToDecimal(parts[2]) });
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void PrintsavedValutes()
        {
            try
            {
                for (int i = 0; i < savedValues.Count; i++)
                {
                    Console.WriteLine("Currency name is:" + savedValues[i].Name + "," + "The code of the currency is:" + savedValues[i].Code + "," + "The rate of the currency is:" + savedValues[i].Rate);
                }
                Console.WriteLine();
            }


            catch (IOException e)
            {
                Console.WriteLine("Unknown error occured!");
                Console.WriteLine(e.Message);
            }
        

        }



        public void DeleteCurrency()
        {
            Console.WriteLine("Enter the currency you want to delete");
            string currency = Console.ReadLine();
            bool isFind = false;
            for (int i = 0; i < savedValues.Count; i++)
            {
                if (!isFind)
                {
                    if (currency == savedValues[i].Name || currency == savedValues[i].Code)
                    {
                        isFind = true;
                        savedValues.RemoveAt(i);
                        Console.WriteLine("Currency deleted succesfuly");
                        WriteFile();
                    }
                }
            }
            if (!isFind)
            {
                Console.WriteLine("Error finding your currency");
            }

        }

        public void Exchange()
        {


            Console.WriteLine("Enter ammount");
            decimal ammount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the currency of the ammount");
            string currency = Console.ReadLine();
            Console.WriteLine("Enter the exchange valute");
            

            string exchange = Console.ReadLine();
            int canConvert = 0;
            decimal fVal = 0, sVal = 0;
            for (int i = 0; i < savedValues.Count; i++)
            {
               if(savedValues[i].Code == currency)
                {
                    canConvert++;
                    fVal = savedValues[i].Rate;
                } 
                else if(savedValues[i].Code == exchange)
                {
                    canConvert++;
                    sVal = savedValues[i].Rate;
                }
               else if(exchange == "EUR")
                {
                    Console.WriteLine(ammount * fVal);
                }

               
            
            }
            if (canConvert == 2)
            {
                Console.WriteLine((fVal * ammount) / sVal);
            }
           
        }
            
        
          
        
            


                  

















        }
    }

