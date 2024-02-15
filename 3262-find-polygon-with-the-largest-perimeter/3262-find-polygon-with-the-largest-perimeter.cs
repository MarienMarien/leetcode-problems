public class Solution {
    public long LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        long totalSum = 0;
        foreach (var n in nums)
            totalSum += n;

        long currSum = totalSum;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if (currSum - nums[i] > nums[i]) {
                break;
            }
            currSum -= nums[i];
        }

        return currSum == 0 ? -1 : currSum;
    }
}