public class Solution {
    public int CountHomogenous(string s) {
        const int MOD = 1_000_000_007;

        var prevLetter = s[0];
        long count = 0;
        var totalCount = 0;

        foreach (var ch in s) {
            if (ch != prevLetter) {
                totalCount += (int)((count * (count + 1) / 2) % MOD);
                prevLetter = ch;
                count = 0;
            }
            count++;
        }

        totalCount += (int)((count * (count + 1) / 2) % MOD);
        
        return totalCount;
    }
}