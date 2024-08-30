public class Solution {
    public bool SquareIsWhite(string coordinates) {
        var xCoord = coordinates[0] - 'a';
        var yCoord = coordinates[1] - '0';
        return xCoord % 2 == yCoord % 2;
    }
}