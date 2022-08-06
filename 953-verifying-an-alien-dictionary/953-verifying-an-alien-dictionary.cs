public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        var alphabet = new Dictionary<char, int>();
        for (var i = 0; i < order.Length; i++) {
            alphabet.Add(order[i], i);
        }
        var isSorted = true;
        for (var i = 1; i < words.Length; i++) {
            if (!IsPairSorted(words[i], words[i - 1], alphabet)) {
                return false;
            }
        }

        return isSorted;
    }

    private bool IsPairSorted(string curr, string prev, Dictionary<char, int> alphabet)
    {
        var len = Math.Min(curr.Length, prev.Length);
        for (var i = 0; i < len; i++) {
            if (prev[i] == curr[i])
                continue;
            return alphabet[prev[i]] < alphabet[curr[i]];
        }
        if (prev.Length > curr.Length)
            return false;
        return true;
    }
}