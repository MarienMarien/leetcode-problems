public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        var map = new Dictionary<string, int>();
        var s1Splitted = s1.Split(' ');
        foreach(var word in s1Splitted) { 
            if (!map.TryAdd(word, 1))
                map[word]++;
        }

        var s2Splitted = s2.Split(' ');
        foreach (var word in s2Splitted) { 
            if (!map.TryAdd(word, 1))
                map[word]++;
        }

        var uncommonWords = new List<string>();

        foreach (var w in map)
        {
            if (w.Value == 1)
            {
                uncommonWords.Add(w.Key);
            }
        }

        return uncommonWords.ToArray();
    }
}