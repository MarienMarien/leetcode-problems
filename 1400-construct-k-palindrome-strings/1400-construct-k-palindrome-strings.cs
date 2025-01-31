public class Solution {
    public bool CanConstruct(string s, int k) {
        if (s.Length < k)
            return false;
        if(s.Length == k)
            return true;

        var oddCount = 0;
        var alphabet = new int[26];
        foreach (var ch in s)
        {
            var key = ch - 'a';
            oddCount += alphabet[key] % 2 == 0 ? 1 : -1;
            alphabet[key]++;
        }

        return oddCount <= k;
    }
}