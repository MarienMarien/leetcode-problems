public class Solution {
    public int MaxOperations(int[] nums, int k) {
        if (nums.Length < 2)
            return 0;
        Array.Sort(nums);
        var left = 0;
        var right = nums.Length - 1;
        var count = 0;
        while (left < right) {
            var currSum = nums[left] + nums[right];
            if (currSum == k) {
                count++;
                left++;
                right--;
                continue;
            }
            if (currSum > k)
                right--;
            else
                left++;
        }
        return count;
    }
}