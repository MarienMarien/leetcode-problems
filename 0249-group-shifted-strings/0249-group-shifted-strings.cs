public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
        var groups = new Dictionary<string, IList<string>>();
        foreach(var s in strings)
        {
            var pattern = new StringBuilder();
            for(var i = 1; i < s.Length; i++)
            {
                pattern.Append((char)((s[i] - s[i - 1] + 26) % 26 + 'a'));
            }
            var patternStr = pattern.ToString();
            if(!groups.TryAdd(patternStr, new List<string> { s }))
                groups[patternStr].Add(s);
        }

        return groups.Values.ToList();
    }
}