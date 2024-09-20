public class Solution {
    public string ShortestPalindrome(string s) {
        if (s.Length < 2)
            return s;

        var left = 0;

        for (var right = s.Length - 1; right >= 0; right--)
        {
            if (s[left] == s[right])
            {
                left++;
            }
        }

        if (left == s.Length)
            return s;

        var prefix = s[left..].Reverse().ToArray();
        var sb = new StringBuilder();
        sb.Append(prefix);
        sb.Append(ShortestPalindrome(s[0..left]));
        sb.Append(s[left..]);

        return sb.ToString();
    }
}