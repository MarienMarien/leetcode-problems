public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        var minPos = -1;
        var maxPos = -1;
        var start = -1;
        long count = 0;
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] < minK || nums[i] > maxK)
                start = i;
            if (nums[i] == minK) {
                minPos = i;
            }
            if (nums[i] == maxK)
                maxPos = i;
            count += Math.Max(0, Math.Min(minPos, maxPos) - start);
        }
        return count;
    }
}