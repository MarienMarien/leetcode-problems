public class Solution {
    public int LenLongestFibSubseq(int[] arr) {
        var len = arr.Length;
        var dp = new int[len, len];
        var maxLen = 0;
        for(var curr = 2; curr < len; curr++)
        {
            var start = 0;
            var end = curr - 1;
            while(start < end)
            {
                var pairSum = arr[start] + arr[end];
                if (pairSum > arr[curr])
                {
                    end--;
                } 
                else if (pairSum < arr[curr])
                {
                    start++;
                } 
                else 
                {
                    dp[end,curr] = dp[start,end] + 1;
                    maxLen = Math.Max(maxLen, dp[end,curr]);
                    start++;
                    end--;
                }
            }
        }

        return maxLen == 0 ? 0 : maxLen + 2;
    }
}