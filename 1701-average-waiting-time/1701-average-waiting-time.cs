public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        var currTime = customers[0][0];
        double totalWaitingTime = 0;
        
        for (var i = 0; i < customers.Length; i++)
        {
            var waitForPrev = currTime - customers[i][0];
            totalWaitingTime += (waitForPrev < 0 ? 0 : waitForPrev) + customers[i][1];
            currTime = customers[i][1] + (waitForPrev < 0 ? customers[i][0] : currTime);
        }

        return totalWaitingTime / customers.Length;
    }
}