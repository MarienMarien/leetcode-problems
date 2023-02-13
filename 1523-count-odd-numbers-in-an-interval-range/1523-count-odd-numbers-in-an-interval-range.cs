public class Solution {
    public int CountOdds(int low, int high) {
        var additional = low % 2 == 0 && low == high ? 0 : 1;
        return additional + (low % 2 == 0 ? (high - (low + 1)) / 2 : (high - low) / 2);
    }
}