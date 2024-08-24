public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        if (prices.Length < 2)
            return maxProfit;
        var buyPrice = prices[0];
        for (var i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - buyPrice);
            if (prices[i] < buyPrice)
                buyPrice = prices[i];
        }
        return maxProfit;
    }
}