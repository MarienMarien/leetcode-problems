public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length;
        var dp = new int[n];
        var prevDiv = new int[n];
        Array.Fill(dp, 1);
        Array.Fill(prevDiv, -1);
        var maxSize = 0;
        var maxId = -1;
        for(var i = 0; i < n; i++)
        {
            for(var j = 0; j < i; j++)
            {
                if(nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prevDiv[i] = j;
                }
            }
            if(dp[i] > maxSize)
            {
                maxSize = dp[i];
                maxId = i;
            }
        }

        var subset = new List<int>();
        while(maxId != -1)
        {
            subset.Add(nums[maxId]);
            maxId = prevDiv[maxId];
        }

        return subset;
    }
}