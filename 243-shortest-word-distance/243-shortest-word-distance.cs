public class Solution {
    public int ShortestDistance(string[] wordsDict, string word1, string word2) {
        var w1i = -1;
        var w2i = -1;
        var res = wordsDict.Length;
        for (var i = 0; i < wordsDict.Length; i++) {
            if (wordsDict[i].Equals(word1))
                w1i = i;
            if (wordsDict[i].Equals(word2))
                w2i = i;
            if (w1i > -1 && w2i > -1)
                res = Math.Min(res, Math.Abs(w1i - w2i));
        }
        return res;
    }
}