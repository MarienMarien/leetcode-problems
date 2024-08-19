public class Solution {
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        const char PLATE = '*';
        const char CANDLE = '|';
        var closestLeftCandle = new int[s.Length];
        var closestRightCandle = new int[s.Length];
        var platesSoFar = new int[s.Length];
        var currPlatesCount = 0;
        var currPlatesSoFar = 0;
        var currClosestLeft = -1;
        var currClosestRight = -1;
        var sLastId = s.Length - 1;

        for(var i = 0; i < s.Length; i++)
        {
            if (s[i] == PLATE && currClosestRight >= 0)
            {
                currPlatesCount++;
            }
            if (s[i] == CANDLE)
            {
                currClosestRight = i;
                currPlatesSoFar += currPlatesCount;
                currPlatesCount = 0;
            }
            closestRightCandle[i] = currClosestRight;
            platesSoFar[i] = currPlatesSoFar;

            if (s[sLastId - i] == CANDLE)
            {
                currClosestLeft = sLastId - i;
            }
            closestLeftCandle[sLastId - i] = currClosestLeft;
        }

        var ans = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            var left = closestLeftCandle[queries[i][0]];
            var right = closestRightCandle[queries[i][1]];
            if (right <= left || right == -1 || left == -1 || queries[i][0] == queries[i][1])
                ans[i] = 0;
            else
                ans[i] = platesSoFar[right] - platesSoFar[left];
        }
        return ans;
    }
}