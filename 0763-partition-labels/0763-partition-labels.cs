public class Solution {
    public IList<int> PartitionLabels(string s) {
        var boundaries = new Dictionary<char, int[]>();
        for(var i = 0; i < s.Length; i++)
        {
            var currChar = s[i];
            if(!boundaries.TryAdd(currChar, new int[] { i, i }))
            {
                boundaries[currChar][1] = i;
            }
        }
        var intervals = boundaries.Values
            .Order(Comparer<int[]>.Create((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0])).ToList();
        var partitionStart = intervals[0][0];
        var partitionEnd = intervals[0][1];
        var partitions = new List<int>();
        for(var i = 1; i < intervals.Count; i++)
        {
            var currStart = intervals[i][0];
            var currEnd = intervals[i][1];
            if(currStart <= partitionEnd)
            {
                partitionEnd = Math.Max(partitionEnd, currEnd);
                continue;
            }

            partitions.Add(partitionEnd - partitionStart + 1);
            partitionStart = currStart;
            partitionEnd = currEnd;
        }

        partitions.Add(partitionEnd - partitionStart + 1);

        return partitions;
    }
}