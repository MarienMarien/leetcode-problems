public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);

        var incCount = 0;

        for (var i = 1; i < nums.Length; i++) {
            if (nums[i] <= nums[i - 1])
            {
                incCount += nums[i - 1] + 1 - nums[i];
                nums[i] = nums[i - 1] + 1;
            }
        }

        return incCount;
    }
}