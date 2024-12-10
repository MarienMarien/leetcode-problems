public class Solution {
    public int MaximumLength(string s) {
        var subStrs = new Dictionary<char, IList<int>>();
        var sId = 0;
        while (sId < s.Length)
        {
            var ch = s[sId];
            var count = 1;
            if (!subStrs.ContainsKey(ch))
                subStrs.Add(ch, new List<int>());

            while (sId < s.Length && s[sId] == ch)
            {
                subStrs[ch].Add(count);
                sId++;
                count++;
            }
        }

        var longest = -1;
        foreach (var sub in subStrs)
        {
            if (sub.Value.Count < 3)
                continue;
            var sortedLen = sub.Value.OrderDescending().ToList();
            longest = Math.Max(longest, sortedLen[2]);
        }

        return longest;
    }
}