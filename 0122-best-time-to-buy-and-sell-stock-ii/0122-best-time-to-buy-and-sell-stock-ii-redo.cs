public class Solution {
    public int MaxProfit(int[] prices) {
        var len = prices.Length - 1;
        var profit = 0;
        var buy = 0;
        var sell = 0;
        var i = 0;
        while(i < len)
        {
            while(i < len && prices[i] >= prices[i+1])
            {
                i++;
            }
            buy = prices[i];
            while(i < len && prices[i] <= prices[i+1])
            {
                i++;
            }
            sell = prices[i];
            profit += sell - buy;
        }
        return Math.Max(profit, 0);
    }
}