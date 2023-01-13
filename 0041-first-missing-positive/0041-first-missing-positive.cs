public class Solution {
    public int FirstMissingPositive(int[] nums) {
        var n = nums.Length;
        var hasOne = false;
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] == 1)
                hasOne = true;
            if (nums[i] < 1 || nums[i] > n)
                nums[i] = 1;
        }
        if (!hasOne)
            return 1;
        for (var i = 0; i < nums.Length; i++) {
            var id = Math.Abs(nums[i]);
            if (id == n)
                nums[0] = -Math.Abs(nums[0]);
            else 
                nums[id] = -Math.Abs(nums[id]);
        }
        for (var i = 1; i < nums.Length; i++)
            if (nums[i] > 0)
                return i;
        if (nums[0] > 0)
            return n;
        return n + 1;
    }
}