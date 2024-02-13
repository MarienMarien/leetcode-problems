public class Solution {
    public int MinCost(int[][] costs) {
        var costRow = new int[3];
        Array.Copy(costs[^1], costRow, costRow.Length);
        
        for (var i = costs.Length - 2; i >= 0; i--)
        {
            var currHouse = new int[3];

            currHouse[0] = costs[i][0] + Math.Min(costRow[1], costRow[2]);
            currHouse[1] = costs[i][1] + Math.Min(costRow[0], costRow[2]);
            currHouse[2] = costs[i][2] + Math.Min(costRow[0], costRow[1]);
            costRow = currHouse;
        }

        return costRow.Min();
    }
}