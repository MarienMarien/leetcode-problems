public class Solution {
    public string Tictactoe(int[][] moves) {
        const int dim = 3;
        var player = 1;
        var rows = new int[3];
        var cols = new int[3];
        var diagonal = 0;
        var antiDiagonal = 0;
        for (var i = 0; i < moves.Length; i++) {
            rows[moves[i][0]] += player;
            cols[moves[i][1]] += player;
            if (moves[i][0] == moves[i][1])
                diagonal += player;
            if (moves[i][0] + moves[i][1] == dim - 1)
                antiDiagonal += player;
            if (Math.Abs(rows[moves[i][0]]) == dim || Math.Abs(cols[moves[i][1]]) == dim || Math.Abs(diagonal) == dim || Math.Abs(antiDiagonal) == dim)
                return player < 0 ? "B" : "A";
            player *= -1;
        }

        return moves.Length == 9 ? "Draw" : "Pending";
    }
}