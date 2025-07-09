public class Solution {
    public int IsWinner(int[] player1, int[] player2) {
        var len = player1.Length;
        var p1Score = 0;
        var p2Score = 0;
        var p1TenId = -3;
        var p2TenId = -3;
        for(var i = 0; i < len; i++)
        {
            var koef = i - p1TenId <= 2 ? 2 : 1;
            p1Score += player1[i] * koef;
            if(player1[i] == 10)
                p1TenId = i;

            koef = i - p2TenId <= 2 ? 2 : 1;
            p2Score += player2[i] * koef;
            if(player2[i] == 10)
                p2TenId = i;
        }
        if(p1Score > p2Score)
            return 1;
        return p1Score == p2Score ? 0 : 2;
    }
}