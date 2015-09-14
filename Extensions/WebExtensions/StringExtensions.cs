namespace Extensions.WebExtensions
{
    public static class StringExtensions
    {
        public static string TruncateAndAddEllipsis(this string input, int length)
        {
            if (input == null || input.Length < length)
                return input;

            var spaceIndex = input.LastIndexOf(" ", length);

            return $"{input.Substring(0, (spaceIndex > 0) ? spaceIndex : length)}...";
        }
    }
}