public class Solution {
    public long MostPoints(int[][] questions) {
        var pointsEarned = new long[questions.Length];
        for(var i = pointsEarned.Length - 1; i >= 0; i--)
        {
            var points = questions[i][0];
            var brainpower = questions[i][1];
            var availableQ = i + brainpower + 1;
            long currGain = points + (availableQ < questions.Length ? pointsEarned[availableQ] : 0);
            long prevGain = i < pointsEarned.Length - 1 ? pointsEarned[i + 1] : 0;
            pointsEarned[i] = Math.Max(currGain, prevGain);
        }

        return pointsEarned[0];
    }
}