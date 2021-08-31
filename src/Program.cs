using System;

namespace MtaSaMapParser
{
    static class Program
    {
        private static void Main(string[] args)
        {
            string from;
            while (true) 
            { 
                Console.WriteLine("Input path to file to parse:");
                from = Console.ReadLine();

                if (Validator.ArePathAndExtensionValid(from))
                    break;
                else
                    Console.WriteLine("Inputed path doesn't exist, or file extension doesn't match " +
                                     $"\"{Shared.RequiredExtension}\"");
            }

            string[] categories;
            while (true)
            {
                Console.WriteLine("Input (in one line) categories which you want to copy to new " +
                                 $"{Shared.RequiredExtension}-file:");
                categories = Console.ReadLine().Split(' ');

                if (Validator.AreCategoriesValid(categories))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input example:");

                    Console.WriteLine($"\t{Shared.ExistingCategories[0]} (or)");
                    Console.WriteLine($"\t{Shared.ExistingCategories[1]} {Shared.ExistingCategories[3]} (or)");
                    Console.WriteLine($"\t{Shared.ExistingCategories[0]} {Shared.ExistingCategories[2]} " +
                                        $"{Shared.ExistingCategories[3]}");
                }
            }
        }
    }
}
