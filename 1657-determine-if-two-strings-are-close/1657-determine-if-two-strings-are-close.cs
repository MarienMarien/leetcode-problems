public class Solution {
    public bool CloseStrings(string word1, string word2) {
        if (word1.Length != word2.Length)
            return false;
        var mapWord1 = new Dictionary<char, int>();
        var mapWord2 = new Dictionary<char, int>();
        foreach (var ch in word2) {
            if (!mapWord2.ContainsKey(ch))
                mapWord2.Add(ch, 0);
            mapWord2[ch]++;
        }
        foreach (var ch in word1)
        {
            if (!mapWord2.ContainsKey(ch))
                return false;
            if (!mapWord1.ContainsKey(ch))
                mapWord1.Add(ch, 0);
            mapWord1[ch]++;
        }
        var word1Values = mapWord1.Values.OrderBy(x => x);
        var word2Values = mapWord2.Values.OrderBy(x => x);
        return Enumerable.SequenceEqual(word1Values, word2Values);
    }
}