public class Solution {
    public int[] FinalPrices(int[] prices) {
        var stack = new Stack<int>();
        var ans = new int[prices.Length];
        for(var i = prices.Length - 1; i >= 0; i--)
        {
            while(stack.Count > 0 && stack.Peek() > prices[i])
                stack.Pop();
            ans[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
            stack.Push(prices[i]);
        }
        return ans;
    }
}