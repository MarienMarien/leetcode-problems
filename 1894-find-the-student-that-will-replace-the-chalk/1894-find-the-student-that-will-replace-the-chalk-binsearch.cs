public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        var chalkUsed = new long[chalk.Length];
        chalkUsed[0] = chalk[0];
        for (var i = 1; i < chalk.Length; i++)
        {
            chalkUsed[i] = chalk[i] + chalkUsed[i - 1];
        }

        var chalkForLastRound = k % chalkUsed[^1];
        if (chalkForLastRound == 0)
            return 0;

        var start = 0;
        var end = chalk.Length - 1;
        while (start < end)
        {
            var mid = (start + end) / 2;
            if (chalkUsed[mid] <= chalkForLastRound)
            {
                start = mid + 1;
            }
            else {
                end = mid;
            }
        }

        return start;
    }
}