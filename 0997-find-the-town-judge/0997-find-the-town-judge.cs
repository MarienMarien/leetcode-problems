public class Solution {
    public int FindJudge(int n, int[][] trust) {
        if (trust.Length == 0)
            return n == 1 ? 1 : -1;
        var trustMap = new Dictionary<int, int>();
        var trustSmnSet = new HashSet<int>();
        var max = -1;
        var maxCount = -1;
        foreach (var t in trust) {
            if (!trustSmnSet.Contains(t[0]))
                trustSmnSet.Add(t[0]);
            if (!trustMap.TryAdd(t[1],1))
                trustMap[t[1]]++;
            if (trustMap[t[1]] > maxCount){
                max = t[1];
                maxCount = trustMap[t[1]];
            }
        }
        if (trustMap[max] == (n - 1) && !trustSmnSet.Contains(max))
            return max;
        return -1;
    }
}