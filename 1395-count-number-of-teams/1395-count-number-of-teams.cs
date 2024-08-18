public class Solution {
    public int NumTeams(int[] rating) {
        Func<int, int, bool> isIncreasing = (a, b) => a < b;
        Func<int, int, bool> isDecreasing = (a, b) => a > b;
        var len = rating.Length;
        var teams = 0;
        var increasingCache = new int[len, 4];
        var decreasingCache = new int[len, 4];

        for (var startId = 0; startId < len - 2; startId++)
        {
            teams += CountTeams(rating, startId, 1, increasingCache, isIncreasing)
                + CountTeams(rating, startId, 1, decreasingCache, isDecreasing);
        }

        return teams;
    }

    private int CountTeams(int[] rating, int currId, int teamSize, int[,] increasingCache, Func<int, int, bool> compare)
    {
        var len = rating.Length;
        if (currId == len)
            return 0;
        if(teamSize == 3)
            return 1;

        if (increasingCache[currId, teamSize] > 0)
            return increasingCache[currId, teamSize];

        var validTeamsCount = 0;

        for (var id = currId + 1; id < len; id++)
        {
            if (compare(rating[id], rating[currId]))
            {
                validTeamsCount += CountTeams(rating, id, teamSize + 1, increasingCache, compare);
            }
        }

        increasingCache[currId, teamSize] = validTeamsCount;
        return validTeamsCount;
    }
}