public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        var bestStart1 = 0;
        var bestStart2 = new int[] { 0, k };
        var bestStart3 = new int[] { 0, k, k * 2 };

        var currentWindowSum1 = 0;
        for (var i = 0; i < k; i++)
        {
            currentWindowSum1 += nums[i];
        }

        var currentWindowSum2 = 0;
        for (var i = k; i < k * 2; i++)
        {
            currentWindowSum2 += nums[i];
        }

        var currentWindowSum3 = 0;
        for (var i = k * 2; i < k * 3; i++)
        {
            currentWindowSum3 += nums[i];
        }

        var bestSum1 = currentWindowSum1;
        var bestSum2 = currentWindowSum1 + currentWindowSum2;
        var bestSum3 = currentWindowSum1 + currentWindowSum2 + currentWindowSum3;

        var startIndex1 = 1;
        var startIndex2 = k + 1;
        var startIndex3 = k * 2 + 1;

        while (startIndex3 <= nums.Length - k)
        {
            currentWindowSum1 = currentWindowSum1 - nums[startIndex1 - 1] + nums[startIndex1 + k - 1];
            currentWindowSum2 = currentWindowSum2 - nums[startIndex2 - 1] + nums[startIndex2 + k - 1];
            currentWindowSum3 = currentWindowSum3 - nums[startIndex3 - 1] + nums[startIndex3 + k - 1];

            if (currentWindowSum1 > bestSum1)
            {
                bestStart1 = startIndex1;
                bestSum1 = currentWindowSum1;
            }

            if (currentWindowSum2 + bestSum1 > bestSum2)
            {
                bestStart2[0] = bestStart1;
                bestStart2[1] = startIndex2;
                bestSum2 = currentWindowSum2 + bestSum1;
            }

            if (currentWindowSum3 + bestSum2 > bestSum3)
            {
                bestStart3[0] = bestStart2[0];
                bestStart3[1] = bestStart2[1];
                bestStart3[2] = startIndex3;
                bestSum3 = currentWindowSum3 + bestSum2;
            }

            startIndex1 += 1;
            startIndex2 += 1;
            startIndex3 += 1;
        }

        return bestStart3;
    }
}