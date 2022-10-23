public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var left = new int[nums.Length];
        left[0] = nums[0];
        var right = new int[nums.Length];
        right[nums.Length - 1] = nums[nums.Length - 1];
        var ans = new int[nums.Length];
        var j = nums.Length - 1;
        for (var i = 1; i < nums.Length; i++)
        {
            left[i] = left[i - 1] * nums[i];
            right[j - i] = right[j - i + 1] * nums[j - i];
        }
        for (var i = 0; i < nums.Length; i++)
        {
            var l = i > 0 ? left[i - 1] : 1;
            var r = i < nums.Length - 1 ? right[i + 1] : 1;
            ans[i] = r * l;
        }
        return ans;
    }
}