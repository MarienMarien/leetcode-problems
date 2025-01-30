public class Solution {
    public int MaxProfit(int[] prices) {
        var buy = prices[0];
        var profit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            profit = Math.Max(profit, prices[i] - buy);
            if(prices[i] < buy)
                buy = prices[i];
        }

        return profit >= 0 ? profit : 0;
    }
}