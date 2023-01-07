public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        
        var startPoint = 0;
        var totalTank = 0;
        var tank = 0;
        for (var i = 0; i < gas.Length; i++) 
        {
            totalTank += gas[i] - cost[i];
            tank += gas[i] - cost[i];
            if (tank < 0)
            {
                startPoint = i + 1;
                tank = 0;
            }
        }
        return totalTank >= 0 ? startPoint : -1;
    }
}