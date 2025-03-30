public class Solution {
    public IList<int> PartitionLabels(string s) {
        var lastOccur = new int[26];
        for(var i = 0; i < s.Length; i++)
        {
            var key = s[i] - 'a';
            lastOccur[key] = i;
        }

        var partitions = new List<int>();
        var partitionEnd = 0;
        var partitionStart = 0;
        for(var i = 0; i < s.Length; i++)
        {
            var key = s[i] - 'a';
            partitionEnd = Math.Max(partitionEnd, lastOccur[key]);
            if(partitionEnd == i)
            {
                partitions.Add(partitionEnd - partitionStart + 1);
                partitionStart = i + 1;
            }
        }

        return partitions;
    }
}