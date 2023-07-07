public class Solution {
    public int MaxConsecutiveAnswers(string answerKey, int k) {
        const char T = 'T';
        const char F = 'F';
        var maxCount = 0;
        var tCount = 0;
        var fCount = 0;
        var windowStartPos = 0;
        for (var i = 0; i < answerKey.Length; i++) {
            if (answerKey[i] == T)
                tCount++;
            else
                fCount++;
            var currMinCount = Math.Min(tCount, fCount);
            if (currMinCount > k)
            {
                if (answerKey[windowStartPos] == T)
                    tCount--;
                else
                    fCount--;
                windowStartPos++;
            }
            else {
                maxCount = Math.Max(maxCount, currMinCount);
            }

        }
        return tCount + fCount;
    }
}