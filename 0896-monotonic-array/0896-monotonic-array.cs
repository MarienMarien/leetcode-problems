public class Solution {
    public bool IsMonotonic(int[] nums) {
        Func<int, int, bool> isIncreasing = (a, b) => a <= b;
        Func<int, int, bool> isDecreasing = (a, b) => a >= b;
        Func<int, int, bool> isMonotonic = null;
        for (var i = 0; i < nums.Length - 1; i++) {
            if (isMonotonic != null) {
                if (!isMonotonic(nums[i], nums[i + 1]))
                    return false;
                continue;
            }
            else
            {
                if (nums[i] == nums[i + 1])
                    continue;
            }
            if (isIncreasing(nums[i], nums[i + 1])) {
                isMonotonic = isIncreasing;
                continue;
            }
            if (isDecreasing(nums[i], nums[i + 1]))
            {
                isMonotonic = isDecreasing;
                continue;
            }
        }
        
        return true;
    }
}