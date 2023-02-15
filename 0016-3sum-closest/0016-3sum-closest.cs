public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        if (nums.Length == 3)
            return nums[0] + nums[1] + nums[2];
        Array.Sort(nums);
        int diff = Int32.MaxValue;
        for (var i = 0; i < nums.Length; i++) {
            var start = i + 1;
            var end = nums.Length - 1;
            while (start < end) {
                var currSum = nums[i] + nums[start] + nums[end];
                var currDiffAbs = Math.Abs(target - currSum);
                if (currDiffAbs == 0)
                    return currSum;
                if (currDiffAbs < Math.Abs(diff)) {
                    diff = target - currSum;
                }
                if (currSum < target)
                    start++;
                else end--;
            }
        }
        return target - diff;
    }
}