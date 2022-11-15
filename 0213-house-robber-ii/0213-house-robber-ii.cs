public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1)
            return nums[0];
        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);
        var stolen1 = new List<int>() { nums[0], Math.Max(nums[0], nums[1]) };
        var stolen2 = new List<int>() { nums[1], Math.Max(nums[1], nums[2]) };
        var i1 = 2;
        var i2 = 3;
        var len = nums.Length - 2;
        for (var i = 2; i < nums.Length - 1; i++)
        {
            if (i1 < nums.Length - 1)
            {
                stolen1.Add(Math.Max(stolen1[i - 2] + nums[i1++], stolen1[i - 1]));
            }
            if (i2 < nums.Length)
            {
                stolen2.Add(Math.Max(stolen2[i - 2] + nums[i2++], stolen2[i - 1]));
            }
            
        }
        return Math.Max(stolen1[stolen1.Count - 1], stolen2[stolen2.Count - 1]);
    }
}