public class Solution {
    private IList<string> result;
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        var set= new HashSet<string>(wordDict);
        result = new List<string>();
        FindAllSentences(s, set, new List<string>());
        return result;
    }

    private void FindAllSentences(string s, HashSet<string> set, List<string> currSentence)
    {
        if (s == "")
        {
            result.Add(string.Join(" ", currSentence));
            return;
        }
        for (var i = 1; i <= s.Length; i++) {
            var word = s[0..i];
            if (!set.Contains(word))
                continue;
            currSentence.Add(word);
            FindAllSentences(s[i..], set, currSentence);
            currSentence.RemoveAt(currSentence.Count - 1);
        }

    }
}