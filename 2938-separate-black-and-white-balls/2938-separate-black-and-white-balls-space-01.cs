public class Solution {
    public long MinimumSteps(string s) {
        var minSteps = 0L;
        var writeToPos = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                minSteps += i - writeToPos;
                writeToPos++;
            }
        }

        return minSteps;
    }
}