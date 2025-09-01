using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public static class Helper
    {
        public static int GetvalidInput(string message, (int min,int max) ValidRange, Func<(int min,int max),int,bool > IsValidRange)
        {
            int value;
            bool isValid=false;
            do
            {
               
                value = ReadInt(message);
                
                if(!IsValidRange.Invoke(ValidRange,value))
                {
                    Console.WriteLine($"Enter a valid Option between {ValidRange.min} and {ValidRange.max}");
                    
                    continue;
                }
                isValid = true;
            } while(!isValid);
            return value;
        }



        public static bool IsValidInput((int min,int max) ValidOption, int input)
        {
            return input >= ValidOption.min && input <= ValidOption.max;
        }
        
        public static int ReadInt(string message)
        {
            int value;
            bool isParsed = false;
            do
            {
                Console.WriteLine( message);
                isParsed = int.TryParse(Console.ReadLine(), out value);
                if (!isParsed)
                {
                    Console.WriteLine("Enter a valid input");
                }
                


            } while (!isParsed);
            return value;
        }


        public static string ReadValidString(string message)
        {
            bool isValid = true;
            string? input;
            do
            {
                Console.WriteLine( message);
                input=Console.ReadLine();
                if(string.IsNullOrWhiteSpace(input))
                {
                    isValid = false;
                }

            } while (!isValid);

            return input.Trim();
        }

        public static TEnum ReadValidEnum<TEnum>(string message) where TEnum : struct, Enum
        {
            bool isValid;
            TEnum result;

            do
            {
                 Console.WriteLine(message);
                 isValid = Enum.TryParse<TEnum>(Console.ReadLine(), true, out  result);
            } while (!isValid);
            
            return result;
        }
    }
}
