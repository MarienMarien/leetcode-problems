public class Solution {
    public long DividePlayers(int[] skill) {
        if(skill.Length == 2)
            return skill[0] * skill[1];

        Array.Sort(skill);
        var lastId = skill.Length - 1;
        var teamSkill = skill[0] + skill[^1];
        long totalChemistry = 0;

        for(var i = 0; i < skill.Length / 2; i++)
        {
            var currTeamSkill = skill[i] + skill[lastId - i];
            if(currTeamSkill != teamSkill)
                return -1;
            totalChemistry += skill[i] * skill[lastId - i];
        }

        return totalChemistry;
    }
}