public class Solution {
    public int MinAreaRect(int[][] points) {
        const int HASHING_KEY = 40001;
        var pointsSet = new HashSet<int>();
        foreach(var point in points)
        {
            var x = point[0];
            var y = point[1];
            pointsSet.Add(HASHING_KEY * x + y);
        }

        int minArea = int.MaxValue;
        for(var i = 0; i < points.Length - 1; i++)
        {
            var point1 = points[i];
            for(var j = i + 1; j < points.Length; j++)
            {
                var point2 = points[j];
                if(IsOnSameAxis(point1, point2))
                    continue;
                var point3Candidate = new int[] { point1[0], point2[1] };
                var point4Candidate = new int[] { point2[0], point1[1] };
                
                var point3Hash = HASHING_KEY * point3Candidate[0] + point3Candidate[1];
                var point4Hash = HASHING_KEY * point4Candidate[0] + point4Candidate[1];

                if(pointsSet.Contains(point3Hash) && pointsSet.Contains(point4Hash))
                {
                    minArea = Math.Min(minArea, GetArea(point3Candidate, point4Candidate));
                }
            }
        }

        return minArea == int.MaxValue ? 0 : minArea;
    }

    private bool IsOnSameAxis(int[] point1, int[] point2)
    {
        return point1[0] == point2[0] || point1[1] == point2[1];
    }

    private int GetArea(int[] point1, int[] point2)
    {
        return Math.Abs(point1[0] - point2[0]) * Math.Abs(point1[1] - point2[1]);
    }
}