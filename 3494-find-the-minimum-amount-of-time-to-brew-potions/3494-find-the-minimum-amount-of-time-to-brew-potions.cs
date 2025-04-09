public class Solution {
    public long MinTime(int[] skill, int[] mana) {
        var potionsCount = mana.Length;
        var startTime = 0L;
        var nextStartTime = 0L;
        var wizardsCount = skill.Length;
        var dp = new long[potionsCount, wizardsCount];
        var lastPotion = potionsCount - 1;
        for(var potion = 0; potion < potionsCount; potion++)
        {
            var currMana = mana[potion];
            var currTime = startTime;
            var nextPotionTimeRequired = 0L;
            for(var wizard = 0; wizard < wizardsCount; wizard++)
            {
                var wizardSkills = skill[wizard];
                currTime += currMana * wizardSkills;
                dp[potion, wizard] = currTime;

                if(potion == lastPotion)
                    continue;
                var startTimeCandidate = currTime;
                if(wizard > 0)
                {
                    nextPotionTimeRequired += skill[wizard - 1] * mana[potion + 1];
                    startTimeCandidate -= nextPotionTimeRequired;
                }
                nextStartTime = Math.Max(nextStartTime, startTimeCandidate);
            }

            startTime = nextStartTime;
        }

        return dp[potionsCount - 1, wizardsCount - 1];
    }
}