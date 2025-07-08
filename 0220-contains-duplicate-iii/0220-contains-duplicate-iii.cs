public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff) {
        var buckets = new Dictionary<int, int>();
        var bucketSize = valueDiff + 1;
        for(var i = 0; i < nums.Length; i++)
        {
            var bucket = (int)Math.Floor((decimal)nums[i] / bucketSize);
            if(buckets.ContainsKey(bucket))
                return true;
            var leftBucket = bucket - 1;
            if(buckets.ContainsKey(leftBucket) && Math.Abs(nums[i] - buckets[leftBucket]) < bucketSize)
                return true;
            var rightBucket = bucket + 1;
            if(buckets.ContainsKey(rightBucket) && Math.Abs(nums[i] - buckets[rightBucket]) < bucketSize)
                return true;
            buckets[bucket] = nums[i];
            if(i >= indexDiff)
            {
                var toRem = nums[i - indexDiff] / bucketSize;
                buckets.Remove(toRem);
            }
        }
        return false;
    }
}