public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        var prefSum = new int[1001];
        foreach(var t in trips)
        {
            var passengersCount = t[0];
            if(passengersCount > capacity)
                return false;
            var from = t[1];
            var to = t[2];
            prefSum[from] += passengersCount;
            prefSum[to] -= passengersCount;
        }

        for(var i = 1; i < prefSum.Length; i++)
        {
            prefSum[i] += prefSum[i - 1];
            if(prefSum[i] > capacity)
                return false;
        }
        return true;
    }
}