namespace Parser
{
    public static class Shared
    {
        public static readonly string[] ExistingCategories =
        {
            "marker",
            "object",
            "ped",
            "pickup",
            "vehicle",
            "removeWorldObject"
        };

        public const string RequiredExtension = ".map";

        public const string mainOpeningTag = "<map";
        public const string mainClosingTag = "</map>";
    }
}
