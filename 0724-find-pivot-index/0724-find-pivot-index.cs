public class Solution {
    public int PivotIndex(int[] nums) {
        var rightSum = 0;
        for (var i = nums.Length - 1; i > 0; i--) {
            rightSum += nums[i];
        }
        var leftSum = 0;
        var id = 0;
        while (id < nums.Length) {
            if (leftSum == rightSum)
                return id;
            leftSum += nums[id];
            rightSum -= id < nums.Length - 1 ? nums[id + 1] : 0;
            id++;
        }
        return -1;
    }
}