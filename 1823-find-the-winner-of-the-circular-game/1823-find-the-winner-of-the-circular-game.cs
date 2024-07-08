public class Solution {
    public int FindTheWinner(int n, int k) {
        var winner = 0;

        for (var i = 1; i <= n; i++) 
        {
            winner = (winner + k) % i;
        }

        return winner + 1;
    }
}