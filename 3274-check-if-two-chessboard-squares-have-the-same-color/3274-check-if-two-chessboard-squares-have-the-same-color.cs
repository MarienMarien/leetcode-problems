public class Solution {
    public bool CheckTwoChessboards(string coordinate1, string coordinate2) {
        var c1IsWhite = (coordinate1[0] - 'a') % 2 == (coordinate1[1] - '0') % 2;
        var c2IsWhite = (coordinate2[0] - 'a') % 2 == (coordinate2[1] - '0') % 2;
        return c1IsWhite == c2IsWhite;
    }
}