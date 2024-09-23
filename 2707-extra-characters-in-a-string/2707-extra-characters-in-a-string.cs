public class Solution {
    public int MinExtraChar(string s, string[] dictionary)
    {
        var len = s.Length;
        var dp = new int[len + 1];
        var dictionarySet = new HashSet<string>(dictionary);
        for (var start = len - 1; start >= 0; start--)
        {
            dp[start] = dp[start + 1] + 1;
            for (var end = start; end < len; end++)
            {
                var subStr = s[start..(end + 1)];
                if (dictionarySet.Contains(subStr))
                {
                    dp[start] = Math.Min(dp[start], dp[end + 1]);
                }
            }
        }

        return dp[0];
    }
}