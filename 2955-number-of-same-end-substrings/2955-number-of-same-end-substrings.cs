public class Solution {
    public int[] SameEndSubstringCount(string s, int[][] queries) {
        var charFreq = new int[26, s.Length];
        for(var i = 0; i < s.Length; i++)
        {
            charFreq[s[i] - 'a', i]++;
        }

        for (var ch = 0; ch < 26; ch++)
        {
            for (var i = 1; i < s.Length; i++)
            {
                charFreq[ch, i] += charFreq[ch, i - 1];
            }
        }

        var counts = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            var left = queries[i][0];
            var right = queries[i][1];
            var sameEndSubstrCount = 0;
            for (var ch = 0; ch < 26; ch++)
            {
                var leftCount = left == 0 ? 0 : charFreq[ch, left - 1];
                var rightCount = charFreq[ch, right];
                var countInRange = rightCount - leftCount;
                sameEndSubstrCount += (countInRange * (countInRange + 1)) / 2;
            }

            counts[i] = sameEndSubstrCount;
        }

        return counts;
    }
}