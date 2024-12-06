public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        var bannedSet = new HashSet<int>(banned);
        var currSum = 0;
        var count = 0;
        for (var i = 1; i <= n; i++)
        {
            if (bannedSet.Contains(i))
                continue;
            currSum += i;
            if (currSum > maxSum)
                break;

            count++;
        }

        return count;
    }
}