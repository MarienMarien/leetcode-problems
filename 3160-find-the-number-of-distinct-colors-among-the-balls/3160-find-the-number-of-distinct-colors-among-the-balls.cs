public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        var balls = new Dictionary<int, int>();
        var colors = new Dictionary<int, int>();
        var distinctColorsCount = 0;
        var distinctColors = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            var ballNo = queries[i][0];
            var newBallColor = queries[i][1];
            var currBallColor = balls.GetValueOrDefault(ballNo);
            if(currBallColor != 0)
            {
                colors[currBallColor]--;
                if(colors[currBallColor] == 0)
                    colors.Remove(currBallColor);
            }
            
            balls[ballNo] = newBallColor;
            if(!colors.TryAdd(newBallColor, 1))
                colors[newBallColor]++;
            distinctColors[i] = colors.Count;
        }

        return distinctColors;
    }
}