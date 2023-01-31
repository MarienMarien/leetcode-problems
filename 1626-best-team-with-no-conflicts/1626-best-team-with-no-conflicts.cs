public class Solution {
    public int BestTeamScore(int[] scores, int[] ages) {
        var len = scores.Length;
        var players = new (int score, int age)[len];
        for (var i = 0; i < len; i++) {
            players[i] = (scores[i], ages[i]);
        }
        Array.Sort(players, (t1, t2) =>
            { 
                if (t1.age == t2.age)
                    return t1.score.CompareTo(t2.score);
                return t1.age.CompareTo(t2.age);
            });
        var dp = new int[len];
        var max = 0;
        for (var i = 0; i < len; i++)
        {
            dp[i] = players[i].score;
            for (var j = 0; j < i; j++) {
                if (players[j].score <= players[i].score)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + players[i].score);
                }
            }
            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}