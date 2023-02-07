public class Solution {
    public int MaximumWealth(int[][] accounts) {
        var max = 0;
        for(var row = 0; row < accounts.Length; row++){
            var currSum = 0;
            for(var col = 0; col < accounts[0].Length; col++){
                currSum += accounts[row][col];
            }
            max = Math.Max(max, currSum);
        }
        return max;
    }
}