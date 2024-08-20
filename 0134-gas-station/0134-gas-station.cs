public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var totalTank = 0;
        var currTank = 0;
        var start = 0;

        for (var i = 0; i < gas.Length; i++)
        {
            var travel = gas[i] - cost[i];
            totalTank += travel;
            currTank += travel;
            if (currTank < 0)
            {
                start = i + 1;
                currTank = 0;
            }
        }

        return totalTank < 0 ? -1 : start;
    }
}