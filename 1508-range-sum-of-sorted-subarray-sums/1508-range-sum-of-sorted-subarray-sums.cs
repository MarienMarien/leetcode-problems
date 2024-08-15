public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        const int MOD = 1_000_000_007;
        var sums = new int[n * (n + 1) / 2];
        var sumsId = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var sum = 0;
            for (var j = i; j < nums.Length; j++) 
            {
                sum += nums[j];
                sums[sumsId++] = sum;
            }
        }

        Array.Sort(sums);
        var rangeSum = 0;

        for (var i = left - 1; i < right; i++)
        {
            rangeSum = (rangeSum + sums[i]) % MOD;
        }

        return rangeSum;
    }
}