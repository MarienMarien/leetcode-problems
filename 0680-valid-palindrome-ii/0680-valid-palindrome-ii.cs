public class Solution {
    public bool ValidPalindrome(string s) {
    return CheckPalindrome(s, 0, s.Length - 1, 0);
    }

    private bool CheckPalindrome(string s, int start, int end, int count)
    {
        while (start < end)
        {
            if (s[start] != s[end])
            {
                if (count >= 1)
                    return false;
                count++;
                return CheckPalindrome(s, start + 1, end, count) || CheckPalindrome(s, start, end - 1, count);
            }
            end--;
            start++;
        }
        return true;
    }
}