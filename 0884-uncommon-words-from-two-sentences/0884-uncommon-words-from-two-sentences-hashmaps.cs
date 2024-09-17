public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        var map = new Dictionary<string, int>();
        var wordStart = 0;
        for(var i = 0; i < s1.Length; i++)
        {
            if(i == s1.Length - 1 || char.IsWhiteSpace(s1[i]))
            {
                var wordLen = i == s1.Length - 1 ? s1.Length - wordStart : i - wordStart;
                var word = s1.Substring(wordStart, wordLen);
                if(!map.TryAdd(word, 1))
                    map[word]++;
                wordStart = i + 1;
            }
        }

        wordStart = 0;
        for(var i = 0; i < s2.Length; i++)
        {
            if(i == s2.Length - 1 || char.IsWhiteSpace(s2[i]))
            {
                var wordLen = i == s2.Length - 1 ? s2.Length - wordStart : i - wordStart;
                var word = s2.Substring(wordStart, wordLen);
                if(!map.TryAdd(word, 1))
                    map[word]++;
                wordStart = i + 1;
            }
        }

        var uncommonWords = new List<string>();

        foreach(var w in map)
        {
            if(w.Value == 1)
            {
                uncommonWords.Add(w.Key);
            }
        }

        return uncommonWords.ToArray();
    }
}