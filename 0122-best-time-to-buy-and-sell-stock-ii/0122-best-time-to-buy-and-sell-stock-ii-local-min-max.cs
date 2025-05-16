public class Solution {
    public int MaxProfit(int[] prices) {
        var profit = 0;
        var buy = prices[0];
        var sell = prices[0];
        var id = 0;
        var n = prices.Length - 1;
        while(id < n)
        {
            while(id < n && prices[id] >= prices[id + 1])
                id++;
            buy = prices[id];
            while(id < n && prices[id] <= prices[id + 1])
                id++;
            sell = prices[id];
            profit += sell - buy;
        }
        return profit;
    }
}