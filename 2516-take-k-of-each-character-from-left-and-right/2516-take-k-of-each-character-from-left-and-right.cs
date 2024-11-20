public class Solution {
    public int TakeCharacters(string s, int k) {
        if (s.Length < k * 3)
            return -1;
        if (k == 0)
            return 0;

        var charFreq = new Dictionary<char, int>();
        var goodCharCount = 0;
        foreach (var ch in s)
        {
            if (!charFreq.TryAdd(ch, 1))
                charFreq[ch]++;
            if (charFreq[ch] == k)
                goodCharCount++;
        }

        if (goodCharCount != 3)
            return -1;

        var maxPossibleDeleted = 0;
        var windowStartId = 0;
        var windowEndId = 0;
        for (; windowEndId < s.Length; windowEndId++)
        {
            charFreq[s[windowEndId]]--;
            if (charFreq[s[windowEndId]] >= k)
                continue;
            maxPossibleDeleted = Math.Max(maxPossibleDeleted, windowEndId - windowStartId);
            while (charFreq[s[windowEndId]] < k)
            {
                charFreq[s[windowStartId]]++;
                windowStartId++;
            }
        }
        maxPossibleDeleted = Math.Max(maxPossibleDeleted, windowEndId - windowStartId);

        return s.Length - maxPossibleDeleted;
    }
}