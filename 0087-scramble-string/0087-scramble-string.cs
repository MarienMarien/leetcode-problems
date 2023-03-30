public class Solution {
    public bool IsScramble(string s1, string s2)
    {
        var len = s1.Length;
        var memo = new bool?[len,len,len+ 1];
        return IsScramble(s1, s2, 0, 0, len, memo);
    }

    private bool IsScramble(string s1, string s2, int i, int j, int len, bool?[,,] memo)
    {
        if (memo[i,j,len] != null)
        {
            return memo[i,j,len].Value;
        }
        if (len == 1)
        {
            memo[i, j, len] = s1[i] == s2[j];
            return memo[i,j,len].Value;
        }
        for (int k = 1; k < len; k++)
        {
            if (IsScramble(s1, s2, i, j, k, memo) && IsScramble(s1, s2, i + k, j + k, len - k, memo))
            {
                memo[i, j, len] = true;
                return memo[i, j, len].Value;
            }
            if (IsScramble(s1, s2, i, j + len - k, k, memo) && IsScramble(s1, s2, i + k, j, len - k, memo))
            {
                memo[i, j, len] = true;
                return memo[i, j, len].Value;
            }
        }
        memo[i,j,len] = false;
        return memo[i, j, len].Value;
    }
}