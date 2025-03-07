public class Solution {
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        const char PLATE = '*';
        const char CANDLE = '|';
        var lastId = s.Length - 1;
        var closestLeftCandle = new int[s.Length];
        var lastLeftCandle = -1;
        var closestRightCandle = new int[s.Length];
        var lastRightCandle = -1;
        var platesSoFar = new int[s.Length];
        var currPlatesCount = 0;

        for(var i = 0; i < s.Length; i++)
        {
            if(s[i] == PLATE && lastRightCandle >= 0)
            {
                currPlatesCount++;
                platesSoFar[i] = i == 0 ? 0 : platesSoFar[i - 1];
            }

            if(s[i] == CANDLE)
            {
                lastRightCandle = i;
                platesSoFar[i] = currPlatesCount; 
            }
            closestRightCandle[i] = lastRightCandle;

            if(s[lastId - i] == CANDLE)
            {
                lastLeftCandle = lastId - i;
            }
            closestLeftCandle[lastId - i] = lastLeftCandle;
        }

        var answer = new int[queries.Length];

        for(var i = 0; i < queries.Length; i++)
        {
            var closestLeft = closestLeftCandle[queries[i][0]];
            var closestRight = closestRightCandle[queries[i][1]];

            if(closestLeft < 0 || closestRight < 0 || closestLeft >= closestRight)
            {
                answer[i] = 0;
                continue;
            }

            answer[i] = platesSoFar[closestRight] - platesSoFar[closestLeft];
        }

        return answer;
    }
}