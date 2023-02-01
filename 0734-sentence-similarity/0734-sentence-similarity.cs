public class Solution {
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if (sentence1.Length != sentence2.Length)
            return false;
        var len = sentence1.Length;
        var dict = new Dictionary<string, HashSet<string>>();
        foreach (var p in similarPairs) {
            dict.TryAdd(p[0], new HashSet<string>());
            dict[p[0]].Add(p[1]);
            dict.TryAdd(p[1], new HashSet<string>());
            dict[p[1]].Add(p[0]);
        }
        for (var i = 0; i < len; i++) {
            if (sentence1[i] != sentence2[i] && (!dict.ContainsKey(sentence1[i]) || !dict[sentence1[i]].Contains(sentence2[i])))
                return false;
        }
        return true;
    }
}