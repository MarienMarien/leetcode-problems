public class Solution {
    public int LongestConsecutive(int[] nums) {
        Array.Sort(nums);
        var maxLen = 0;
        var currLen = 0;
        for (var i = 0; i < nums.Length; i++) {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            if (i > 0 && nums[i] - nums[i - 1] > 1)
            {
                maxLen = Math.Max(maxLen, currLen);
                currLen = 1;
            }
            else
                currLen++;
        }
        maxLen = Math.Max(maxLen, currLen);
        return maxLen;
    }
}