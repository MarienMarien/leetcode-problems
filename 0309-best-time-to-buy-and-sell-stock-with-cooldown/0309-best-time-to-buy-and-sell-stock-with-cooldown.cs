public class Solution {
    public int MaxProfit(int[] prices) {
        var held = Int32.MinValue;
        var sold = Int32.MinValue;
        var reset = 0;
        foreach ( var price in prices ) {
            var prevSold = sold;
            sold = held + price;
            held = Math.Max(held, reset - price);
            reset = Math.Max(reset, prevSold);
        }
        return Math.Max(reset, sold);
    }
}