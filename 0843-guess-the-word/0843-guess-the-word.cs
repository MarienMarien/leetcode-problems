/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    public void FindSecretWord(string[] words, Master master) {
        IList<string> wordsList = words.ToList();
        var rand = new Random();
        while(wordsList.Count > 0)
        {
            var randId = rand.Next(wordsList.Count);
            var word = wordsList[randId];
            var matchCount = master.Guess(word);
            if(matchCount == 6)
                return;
            wordsList = RemoveUnfitWords(wordsList, word, matchCount);
        }
    }

    private IList<string> RemoveUnfitWords(IList<string> words, string pivotWord, int currMatchCount)
    {
        var candidates = new List<string>();
        foreach(var w in words)
        {
            if(w == pivotWord)
                continue;
            var wordsMatch = CountMatches(w, pivotWord);
            if(wordsMatch == currMatchCount)
                candidates.Add(w);
        }
        return candidates;
    }

    private int CountMatches(string s1, string s2)
    {
        var matchCount = 0;
        for(var i = 0; i < s1.Length; i++)
        {
            if(s1[i] == s2[i])
                matchCount++;
        }
        return matchCount;
    }
}