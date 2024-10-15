public class Solution {
    public long MinimumSteps(string s) {
        var sArr = s.ToCharArray();
        var minSteps = 0L;
        var leftmostZeroId = 0;
        for (var i = 0; i < sArr.Length; i++)
        {
            if (sArr[i] == '1')
                continue;

            if (sArr[leftmostZeroId] == '1')
            {
                minSteps += i - leftmostZeroId;
                var tmp = sArr[leftmostZeroId];
                sArr[leftmostZeroId] = sArr[i];
                sArr[i] = tmp;
            }
            leftmostZeroId++;
        }

        return minSteps;
    }
}