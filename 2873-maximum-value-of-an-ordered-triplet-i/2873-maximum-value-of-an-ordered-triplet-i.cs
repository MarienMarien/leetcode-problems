public class Solution {
    public long MaximumTripletValue(int[] nums) {
        var n = nums.Length;
        var maxLeft = new int[n];
        var maxRight = new int[n];
        var lastId = n - 1;
        for(var i = 1; i < n; i++)
        {
            maxLeft[i] = Math.Max(maxLeft[i - 1], nums[i - 1]);
            maxRight[lastId - i] = Math.Max(maxRight[n - i], nums[n - i]);
        }
        var maxValue = 0L;
        for(var i = 1; i < lastId; i++)
        {
            long candidate = 1L * (maxLeft[i] - nums[i]) * maxRight[i];
            if(candidate > maxValue)
                maxValue = candidate;
        }

        return maxValue;
    }
}