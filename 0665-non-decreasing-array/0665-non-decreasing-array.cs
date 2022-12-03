public class Solution {
    public bool CheckPossibility(int[] nums) {
        var count = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                count++;
                if (i > 0 && nums[i + 1] < nums[i - 1]) 
                    nums[i + 1] = nums[i];
                else 
                    nums[i] = nums[i + 1];
            }
        }

        return count <= 1;
    }
}