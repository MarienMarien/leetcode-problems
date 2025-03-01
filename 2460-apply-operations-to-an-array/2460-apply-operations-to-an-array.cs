public class Solution {
    public int[] ApplyOperations(int[] nums) {
        for(var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
        }

        var zeroId = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
                continue;
            var nonZeroVal = nums[i];
            nums[i] = 0;
            nums[zeroId] = nonZeroVal;
            zeroId++;
        }

        return nums;
    }
}