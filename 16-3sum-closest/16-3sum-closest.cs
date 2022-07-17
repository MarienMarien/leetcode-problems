public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        if (nums.Length == 3)
            return nums[0] + nums[1] + nums[2];
        Array.Sort(nums);
        var diff = Int32.MaxValue;
        for (var i = 0; i < nums.Length - 2; i++) {
            var start = i + 1;
            var end = nums.Length - 1;
            while (start < end) {
                var tmpSum = nums[i] + nums[start] + nums[end];
                
                if (Math.Abs(target - tmpSum) < Math.Abs(diff))
                {
                    diff = target - tmpSum;
                }
                if (tmpSum < target) start++;
                else end--;
            }
        }
        return target - diff;
    }
}