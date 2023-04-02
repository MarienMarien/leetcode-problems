public class Solution {
    public int ShortestWordDistance(string[] wordsDict, string word1, string word2) {
        var w1Id = -1;
        var w2Id = -1;
        var minDist = Int32.MaxValue;
        for (var i = 0; i < wordsDict.Length; i++) {
            if (wordsDict[i] == word1) {
                var currId = w1Id < 0 ? i : w1Id;
                if (w2Id >= 0)
                {
                    minDist = Math.Min(minDist, Math.Abs(currId - w2Id));
                }
                else if (w1Id >= 0 && word1 == word2) {
                    minDist = Math.Min(minDist, Math.Abs(currId - i));
                }
                w1Id = i;
            }
            else if (wordsDict[i] == word2) {
                var currId = w2Id < 0 ? i : w2Id;
                if (w1Id >= 0)
                {
                    minDist = Math.Min(minDist, Math.Abs(w1Id - currId));
                }
                w2Id = i;
            }
        }
        minDist = Math.Min(minDist, Math.Abs(w1Id - w2Id));
        return minDist;
    }
}