public class Solution {
    public int MaximumLength(string s) {
        var subStrs = new Dictionary<char, PriorityQueue<int, int>>();
        var sId = 0;
        while (sId < s.Length)
        {
            var ch = s[sId];
            var count = 1;
            if (!subStrs.ContainsKey(ch))
                subStrs.Add(ch, new PriorityQueue<int, int>());

            while (sId < s.Length && s[sId] == ch)
            {
                subStrs[ch].Enqueue(count, count);
                if (subStrs[ch].Count > 3)
                    subStrs[ch].Dequeue();
                sId++;
                count++;
            }
        }

        var longest = -1;
        foreach (var sub in subStrs)
        {
            if (sub.Value.Count < 3)
                continue;
            var sortedLen = sub.Value.Dequeue();
            longest = Math.Max(longest, sortedLen);
        }

        return longest;
    }
}