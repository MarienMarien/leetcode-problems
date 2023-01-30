public class Solution {
    public bool NimGame(int[] piles) {
        var sum = 0;
        foreach (var p in piles)
            sum ^= p;
        return sum != 0;
    }
}