public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff) {
        var buckets = new Dictionary<int, int>();
        var min = nums.Min();
        var bucketSize = valueDiff + 1;
        var maxBuckets = indexDiff + 1;
        for(var i = 0; i < nums.Length; i++)
        {
            var label = (nums[i] - min) / bucketSize;

            if(buckets.ContainsKey(label))
                return true;
            var leftLabel = label - 1;
            if(buckets.ContainsKey(leftLabel) && Math.Abs(buckets[leftLabel] - nums[i]) <= valueDiff)
                return true;
            var rightLabel = label + 1;
            if(buckets.ContainsKey(rightLabel) && Math.Abs(buckets[rightLabel] - nums[i]) <= valueDiff)
                return true;

            buckets[label] = nums[i];
            if(buckets.Count == maxBuckets)
            {
                var remLabel = (nums[i - indexDiff] - min) / bucketSize;
                buckets.Remove(remLabel);
            }
        }
        return false;
    }
}