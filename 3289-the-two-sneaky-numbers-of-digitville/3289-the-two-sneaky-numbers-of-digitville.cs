public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        Array.Sort(nums);
        var ans = new int[2];
        var ansId = 0;
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i - 1] == nums[i])
            {
                ans[ansId++] = nums[i];
            }
        }

        return ans;
    }
}