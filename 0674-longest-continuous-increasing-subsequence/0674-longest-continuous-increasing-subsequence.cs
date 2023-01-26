public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        var maxLen = 0;
        var start = 0;
        var end = 0;
        for (end = 0; end < nums.Length; end++) {
            if (end > 0 && nums[end] <= nums[end - 1]) {
                maxLen = Math.Max(maxLen, end - start);
                start = end;
            }
        }
        maxLen = Math.Max(maxLen, end - start);

        return maxLen;
    }
}