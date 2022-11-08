public class Solution {
    public int[] SortedSquares(int[] nums) {
        var res = new int[nums.Length];
        var start = 0;
        var end = nums.Length - 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            int curr;
            if (Math.Abs(nums[start]) > Math.Abs(nums[end])) {
                curr = nums[start];
                start++;
            } else {
                curr = nums[end];
                end--;
            }
            res[i] = curr * curr;
        }
        return res;
    }
}