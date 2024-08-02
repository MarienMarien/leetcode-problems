public class Solution {
    public int MinSwaps(int[] nums) {
        var total = nums.Sum();
        if (total == 0 || total == nums.Length)
            return 0;

        var currSwaps = 0;
        var minSwap = Int32.MaxValue;
        var windowStart = 0;

        var len = nums.Length;
        var startMoveWindowIn = total;

        for (var i = 0; i < len + total - 1; i++)
        {
            if (startMoveWindowIn <= 0)
            {
                minSwap = Math.Min(minSwap, currSwaps);
                currSwaps -= nums[windowStart] == 0 ? 1 : 0;
                windowStart++;
            }
            
            currSwaps += nums[i % len] == 0 ? 1 : 0;
            startMoveWindowIn--;
        }

        minSwap = Math.Min(minSwap, currSwaps);

        return minSwap;
    }
}