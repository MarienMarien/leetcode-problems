public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, Comparer<int[]>.Create(
            (x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0])
        );
        var prevEnd = 0;
        var count = 0;
        foreach(var m in meetings)
        {
            var currStart = m[0];
            var currEnd = m[1];
            if(currStart <= prevEnd)
            {
                prevEnd = Math.Max(prevEnd, currEnd);
                continue;
            }
            count += currStart - prevEnd - 1;
            prevEnd = currEnd;
        }

        count += days - prevEnd;

        return count;
    }
}