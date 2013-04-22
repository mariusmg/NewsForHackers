using System.Text.RegularExpressions;

namespace voidsoft.HackerNews.Context
{
    public static class Utils
    {
        private const string HTML_TAG_PATTERN = "<.*?>";


        public static string StripHTML(string inputString)
        {
            return Regex.Replace(inputString, HTML_TAG_PATTERN, string.Empty);
        }
    }
}