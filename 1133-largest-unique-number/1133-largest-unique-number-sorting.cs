public class Solution {
    public int LargestUniqueNumber(int[] nums) {
        Array.Sort(nums);
        var lastId = nums.Length - 1;

        for(var i = lastId; i >= 0; i--)
        {
            var repCount = 1;
            while(i > 0 && nums[i] == nums[i - 1])
            {
                i--;
                repCount++;
            }
            if(repCount == 1)
                return nums[i];
        }

        return -1;
    }
}