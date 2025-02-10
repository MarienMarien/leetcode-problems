public class Solution {
    public int MinimumOperations(int[] nums) {
        Array.Sort(nums);
        var opCount = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
                continue;
            if(i == 0 || nums[i] != nums[i - 1])
                opCount++;
        }

        return opCount;
    }
}