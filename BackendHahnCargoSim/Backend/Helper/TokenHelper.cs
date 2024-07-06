namespace Backend.Helper;

public class TokenHelper
{
    public static string TokenRegex(string token)
    {
        return System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }
}