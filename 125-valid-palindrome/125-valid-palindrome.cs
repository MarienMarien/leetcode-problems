public class Solution {
    public bool IsPalindrome(string s) {
        if (s.Length < 2)
            return true;
        var start = 0;
        var end = s.Length - 1;
        while (start <= end) {
            if (!char.IsLetterOrDigit(s[start]))
            {
                start++;
                continue;
            }
            if (!char.IsLetterOrDigit(s[end])) 
            {
                end--;
                continue;
            }
            if (char.ToLower(s[start]) != char.ToLower(s[end]))
                return false;
            start++;
            end--;
        }
        return true;
    }
}