public class Solution {
    public long DistinctNames(string[] ideas) {
        long count = 0;
        var map = new HashSet<string>[26];
        for (var i = 0; i < 26; i++)
            map[i] = new HashSet<string>();
        foreach (var idea in ideas)
        {
            map[idea[0] - 'a'].Add(idea[1..]);
        }
        for (var i = 0; i < 25; ++i) {
            for (var j = i + 1; j < 26; ++j) {
                long commonCount = 0;
                foreach (var s in map[i]) {
                    if (map[j].Contains(s))
                        commonCount++;
                }
                count += 2 * (map[i].Count - commonCount) * (map[j].Count - commonCount);
            }
        }
        return count;
    }
}