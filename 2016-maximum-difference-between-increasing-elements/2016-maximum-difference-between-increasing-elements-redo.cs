public class Solution {
    public int MaximumDifference(int[] nums) {
        var maxDiff = -1;
        var minSoFar = nums[0];
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] > minSoFar)
                maxDiff = Math.Max(maxDiff, nums[i] - minSoFar);
            else
                minSoFar = nums[i];
        }

        return maxDiff;
    }
}