public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);

        var incCount = 0;

        var prevNum = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= prevNum)
            {
                incCount += prevNum + 1 - nums[i];
                prevNum += 1;
            }
            else {
                prevNum = nums[i];
            }
        }

        return incCount;
    }
}