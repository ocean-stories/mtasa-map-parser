using System;
using System.IO;

namespace Parser
{
    public static class Validator
    {
        public static bool ArePathAndExtensionValid(string path)
        {
            return File.Exists(path) && Path.GetExtension(path) == Shared.RequiredExtension;
        }

        public static bool AreCategoriesValid(string[] categories)
        {
            foreach (string category in categories)
                if (!Array.Exists(Shared.ExistingCategories, element => element == category))
                    return false;

            return true;
        }
    }
}
