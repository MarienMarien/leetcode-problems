public class Solution {
    public int FindDuplicate(int[] nums) {
        var ans = 0;
        for (var i = 0; i < nums.Length; i++) {
            var id = Math.Abs(nums[i]);
            if (nums[id] < 0)
            {
                ans = id;
                break;
            }
            nums[id] = -nums[id];
        }
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] < 0)
                nums[i] = Math.Abs(nums[i]);
        }

        return ans;
    }
}