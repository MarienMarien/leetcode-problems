public class Solution {
    public int MaxScore(string s) {
        const char ONE = '1';
        var left = s[0] == ONE ? 0 : 1;
        var right = 0;
        for(var i = 1; i < s.Length; i++)
            if(s[i] == ONE)
                right++;
        var maxScore = 0;
        for(var i = 1; i < s.Length; i++)
        {
            maxScore = Math.Max(maxScore, left + right);
            if(s[i] == ONE)
                right--;
            else
                left++;
        }

        return maxScore;
    }
}