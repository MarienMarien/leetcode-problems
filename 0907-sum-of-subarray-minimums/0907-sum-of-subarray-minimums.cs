public class Solution {
    public int SumSubarrayMins(int[] arr)
    {
        const int MOD = 1_000_000_007;
        long sum = 0;
        var stack = new Stack<int>();

        for (var i = 0; i <= arr.Length; i++) 
        {
            while (stack.Count > 0 && (i == arr.Length || arr[stack.Peek()] >= arr[i])) 
            { 
                var b = stack.Pop();
                var a = stack.Count > 0 ? stack.Peek() : -1;
                var c = i;
                long subarrCount = ((c - b) * (b - a)) % MOD;
                sum +=(subarrCount * arr[b]) % MOD;
                sum %= MOD;
            }

            stack.Push(i);
        }

        return (int)sum % MOD;
    }
}