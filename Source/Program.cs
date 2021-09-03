using System;
using System.IO;

namespace Parser
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string pathFrom;
            while (true) 
            { 
                Console.WriteLine("Input path to file to parse:");
                pathFrom = Console.ReadLine();

                // Check path for existence and extension to match required
                if (Validator.ArePathAndExtensionValid(pathFrom))
                    break;
                else
                    Console.WriteLine("Inputed path doesn't exist  or file extension doesn't match " +
                                     $"\"{Shared.RequiredExtension}\"");
            }

            string[] categoriesToLeave;
            while (true)
            {
                Console.WriteLine("Input (in one line) categories which you want to leave " +
                                 $"{Shared.RequiredExtension}-file:");
                categoriesToLeave = Console.ReadLine().Split(' ');

                // Check does entered categories match existing
                if (Validator.AreCategoriesValid(categoriesToLeave))
                {
                    break;
                }
                else
                {
                    // Write all availavle categories
                    Console.WriteLine("List of available categories:");
                    foreach (string availableCategory in Shared.ExistingCategories)
                        Console.WriteLine($"\t{availableCategory}");

                    // Write examples of input
                    Console.WriteLine("Input example:");
                    Console.WriteLine($"\t{Shared.ExistingCategories[0]} (or)");
                    Console.WriteLine($"\t{Shared.ExistingCategories[1]} {Shared.ExistingCategories[3]} (or)");
                    Console.WriteLine($"\t{Shared.ExistingCategories[0]} {Shared.ExistingCategories[2]} " +
                                        $"{Shared.ExistingCategories[3]}");
                }
            }

            // Generate name of new file
            string pathTo = 
                $@"{Path.GetDirectoryName(pathFrom)}\" +
                Path.GetFileNameWithoutExtension(pathFrom) +
                '_' +
                DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") +
                Path.GetExtension(pathFrom);
            
            Console.WriteLine($"New {Shared.RequiredExtension}-file — \"{pathTo}\"");

            // Remove categories which wasn't entered
            {
                using var reader = new StreamReader(pathFrom);
                using var writer = new StreamWriter(File.Create(pathTo));

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    bool isNeedToRemove = true;
                    foreach (string categoryToLeave in categoriesToLeave)
                    {
                        string closingTagToFind = $"</{categoryToLeave}>";
                        if (line.Contains(closingTagToFind))
                        {
                            isNeedToRemove = false;
                        }
                    }

                    // Skip lines with root element
                    if (line.Contains(Shared.mainOpeningTag) || 
                        line.Contains(Shared.mainClosingTag))
                    {
                        isNeedToRemove = false;
                    }
                    
                    if (!isNeedToRemove)
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
