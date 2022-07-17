public class Solution {
    public string LongestPalindrome(string s) {
         if (s.Length <= 1)
                return s;
            var len = s.Length;
            var longestPalindromeStart = 0;
            var longestPalindromeLen = 1;
            var right = 0;
            var left = 0;
            var palindromeLen = 0;
            for (var i = 0; i < len; i++) {
                right = i;
                while (right < len && s[i] == s[right]) {
                    right += 1;
                }
                left = i - 1;
                while (left >= 0 && right < len && s[left] == s[right]) {
                    left -= 1;
                    right += 1;
                }
                palindromeLen = right - left - 1;
                if (palindromeLen > longestPalindromeLen) {
                    longestPalindromeLen = palindromeLen;
                    longestPalindromeStart = left + 1;
                }
            }

            return s.Substring(longestPalindromeStart, longestPalindromeLen);
    }
}