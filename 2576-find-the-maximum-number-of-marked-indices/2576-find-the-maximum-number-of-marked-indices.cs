public class Solution {
    public int MaxNumOfMarkedIndices(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length;
        var i = 0;
        var j = (n + 1) / 2;
        while (j < n) {
            if (nums[i] * 2 <= nums[j])
                i++;
            j++;
        }
        return i * 2;
    }
}