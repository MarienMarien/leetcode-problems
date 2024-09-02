public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        long chalkUsedDuringRound = 0;
        foreach(var c in chalk)
        {
            chalkUsedDuringRound += c;
        }
        var chalkBeforeReplace = k % chalkUsedDuringRound;
        var studentToReplaceChalk = 0;
        for(; studentToReplaceChalk < chalk.Length; studentToReplaceChalk++)
        {
            if(chalkBeforeReplace < chalk[studentToReplaceChalk])
                break;
            chalkBeforeReplace -= chalk[studentToReplaceChalk];
        }

        return studentToReplaceChalk;
    }
}