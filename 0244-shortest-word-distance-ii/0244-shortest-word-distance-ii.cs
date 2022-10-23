public class WordDistance {

    private string[] _wordsDict;
    private Dictionary<string, List<int>> _words;
    public WordDistance(string[] wordsDict)
    {
        _wordsDict = wordsDict;
        _words = new Dictionary<string, List<int>>();
        for (var i = 0; i < wordsDict.Length; i++) {
            if (!_words.ContainsKey(wordsDict[i]))
            {
                _words.Add(wordsDict[i], new List<int>() { i });
            }
            else
                _words[wordsDict[i]].Add(i);
        }
    }

    public int Shortest(string word1, string word2)
    {
        var list1 = _words[word1].Count >= _words[word2].Count ? _words[word1] : _words[word2];
        var list2 = _words[word1].Count >= _words[word2].Count ? _words[word2] : _words[word1];
        var res = Int32.MaxValue;
        var l1Id = 0;
        var l2Id = 0;
        while(l1Id < list1.Count) {

            res = Math.Min(res, Math.Abs(list1[l1Id] - list2[l2Id]));
            if (l2Id < list2.Count - 1 && Math.Abs(list1[l1Id] - list2[l2Id]) >= Math.Abs(list1[l1Id] - list2[l2Id + 1]))
                l2Id++;
            else
                l1Id++;
        }
        return res;
    }
}

/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(wordsDict);
 * int param_1 = obj.Shortest(word1,word2);
 */