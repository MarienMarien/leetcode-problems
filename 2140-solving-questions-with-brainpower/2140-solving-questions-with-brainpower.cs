public class Solution {
    public long MostPoints(int[][] questions) {
        int len = questions.Length;
        long[] pointsPerQuestion = new long[len];
        long maxPoints = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            int nextPointId = questions[i][1] + i + 1;
            pointsPerQuestion[i] = questions[i][0] + (nextPointId < len ? pointsPerQuestion[nextPointId] : 0);
            pointsPerQuestion[i] = Math.Max(pointsPerQuestion[i], maxPoints);
            maxPoints = Math.Max(maxPoints, pointsPerQuestion[i]);
        }
        return maxPoints;
    }
}