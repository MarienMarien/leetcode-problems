public class Solution {
    public int MaximumSum(int[] nums) {
        var sums = new Dictionary<int, (int large1, int large2)>();
        foreach(var n in nums)
        {
            var digitSum = GetDigitSum(n);
            if(!sums.TryAdd(digitSum, (n, 0)))
            {
                var entry = sums[digitSum];

                if(entry.large1 < n)
                {
                    entry.large2 = entry.large1;
                    entry.large1 = n;
                }
                else if(entry.large2 < n)
                    entry.large2 = n;
                sums[digitSum] = entry;
            }
        }

        var maxSum = -1;
        foreach(var entry in sums)
        {
            if(entry.Value.large2 == 0)
                continue;
            maxSum = Math.Max(maxSum, entry.Value.large1 + entry.Value.large2);
        }

        return maxSum;
    }

    private int GetDigitSum(int n)
    {
        var sum = 0;
        while(n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
    }
}