public class Solution {
    public bool CanConstruct(string s, int k) {
        if (s.Length < k)
            return false;

        var alphabet = new Dictionary<char, int>();
        foreach (var ch in s)
        {
            if (!alphabet.TryAdd(ch, 1))
                alphabet[ch]++;
        }

        var oddCount = 0;
        foreach (var entry in alphabet)
        {
            if(entry.Value % 2 == 1)
                oddCount++;
        }

        return oddCount <= k;
    }
}