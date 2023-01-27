public class Solution {
    private IList<string> _result;
    private ISet<string> _words;
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        _words = new HashSet<string>(words);
        _result = new List<string>();
        foreach (var w in words) {
            if(IsConcatenated(w, 0))
                _result.Add(w);
        }
        return _result;
    }

    private bool IsConcatenated(string word, int start)
    {
        if (start >= word.Length)
        {
            return true;
        }
        var isConcatenated = false;
        for (var i = start; i < word.Length; i++) {
            var subStr = word[start..(i + 1)];
            if (subStr.Length == word.Length)
                continue;
            if (_words.Contains(subStr)) {
                isConcatenated = IsConcatenated(word, i + 1);
                if (isConcatenated)
                    break;
            }
        }
        return isConcatenated;
    }
}