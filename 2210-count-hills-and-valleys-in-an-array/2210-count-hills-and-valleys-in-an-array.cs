public class Solution {
    public int CountHillValley(int[] nums) {
        var prev = nums[0];
        var count = 0;
        for(var i = 1; i < nums.Length - 1; i++)
        {
            if(nums[i + 1] != nums[i])
            {
                if((prev < nums[i] && nums[i] > nums[i + 1])
                    || (prev > nums[i] && nums[i] < nums[i + 1]))
                    count++;
                prev = nums[i];
                continue;
            }
            
        }
        return count;
    }
}