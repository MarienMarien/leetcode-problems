public class Solution {
    public int MaxProfit(int[] prices) {
         if (prices == null || prices.Length < 2)
                return 0;

            int ans = 0;
            int bought = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > bought)
                {
                    if (ans < (prices[i] - bought))
                    {
                        ans = prices[i] - bought;
                    }
                }
                else
                {
                    bought = prices[i];
                }
            }
            return ans;
    }
}