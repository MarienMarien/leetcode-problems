public class Solution {
    public int ShortestDistance(string[] wordsDict, string word1, string word2) {
        string firstWord = null;
        var distance = Int32.MaxValue;
        var currDistance = 0;
        for (var i = 0; i < wordsDict.Length; i++) {
            if (firstWord == null) {
                if (wordsDict[i] == word1)
                {
                    firstWord = word1;
                    currDistance++;
                }
                if (wordsDict[i] == word2)
                {
                    firstWord = word2;
                    currDistance++;
                }
                continue;
            }
            if (wordsDict[i] == word1 || wordsDict[i] == word2) {
                if (wordsDict[i] == firstWord)
                {
                    currDistance = 0;
                }
                else {
                    distance = Math.Min(distance, currDistance);
                    firstWord = wordsDict[i];
                    currDistance = 0;
                }
            }
            currDistance++;
        }

        return distance;
    }
}