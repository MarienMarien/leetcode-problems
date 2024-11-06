public class Solution {
    public bool CanSortArray(int[] nums) {
        var len = nums.Length;
        var prevMax = 0;
        var currMin = 0;
        var currMax = 0;
        var prevBitCount = 0;
        foreach (var n in nums) {
            var nBitCount = Int32.PopCount(n);
            if (prevBitCount == nBitCount) {
                currMin = Math.Min(currMin, n);
                currMax = Math.Max(currMax, n);
            } else if (currMin < prevMax)
            {
                return false;
            }
            else
            {
                prevMax = currMax;
                currMin = currMax = n;
                prevBitCount = nBitCount;
            }
        }
        return currMin >= prevMax;
    }
}