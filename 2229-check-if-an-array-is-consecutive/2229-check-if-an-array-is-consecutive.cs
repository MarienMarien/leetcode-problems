public class Solution {
    public bool IsConsecutive(int[] nums) {
        Array.Sort(nums);
        var startRange = nums[0];
        var endRange = startRange + nums.Length - 1;
        var i = 0;
        while (startRange <= endRange && i < nums.Length) {
            if (nums[i] == startRange) {
                startRange++;
            }
            i++;
        }
        return startRange == endRange + 1;
    }
}