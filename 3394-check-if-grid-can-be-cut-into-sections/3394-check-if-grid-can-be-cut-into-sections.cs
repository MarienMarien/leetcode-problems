public class Solution {
    public bool CheckValidCuts(int n, int[][] rectangles) {
        var rCount = rectangles.Length;
        var xAxis = new int[rCount][];
        var yAxis = new int[rCount][];
        var minStartX = int.MaxValue;
        var minStartY = int.MaxValue;
        for(var i = 0; i < rCount; i++)
        {
            var startX = rectangles[i][0];
            var endX = rectangles[i][2];
            xAxis[i] = new int[] { startX, endX };
            minStartX = Math.Min(minStartX, startX);
            var startY = rectangles[i][1];
            var endY = rectangles[i][3];
            yAxis[i] = new int[] { startY, endY };
            minStartY = Math.Min(minStartY, startY);
        }
        Array.Sort(xAxis, Comparer<int[]>.Create((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0]));
        Array.Sort(yAxis, Comparer<int[]>.Create((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0]));
        var prevEnd = xAxis[0][1];
        var cutsCount = 0;
        foreach(var x in xAxis)
        {
            var currStart = x[0];
            var currEnd = x[1];
            if(currStart >= prevEnd)
            {
                cutsCount++;
                prevEnd = currEnd;
                continue;
            }

            prevEnd = Math.Max(prevEnd, currEnd);
        }

        if(cutsCount >= 2)
            return true;
        
        cutsCount = 0;
        prevEnd = yAxis[0][1];
        foreach(var y in yAxis)
        {
            var currStart = y[0];
            var currEnd = y[1];
            if(currStart >= prevEnd)
            {
                cutsCount++;
                prevEnd = currEnd;
                continue;
            }

            prevEnd = Math.Max(prevEnd, currEnd);
        }

        return cutsCount >= 2;
    }
}