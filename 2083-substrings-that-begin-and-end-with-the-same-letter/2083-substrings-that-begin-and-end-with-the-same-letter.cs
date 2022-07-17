public class Solution {
    public long NumberOfSubstrings(string s) {
        var letterCount = new Dictionary<char, long>();
            long cnt = 0;
            foreach (var c in s) {
                if (!letterCount.ContainsKey(c))
                    letterCount.Add(c, 0);
                cnt += ++letterCount[c];
            }
            return cnt;
    }
}