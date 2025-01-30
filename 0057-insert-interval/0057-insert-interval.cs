public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var newIntervalStart = newInterval[0];
        var newIntervalEnd = newInterval[1];
        Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0].CompareTo(y[0])));
        
        var result = new List<int[]>();
        var i = 0;
        var intervalsLen = intervals.Length;
        while(i < intervalsLen && intervals[i][1] < newIntervalStart)
        {
            result.Add(intervals[i]);
            i++;
        }

        while(i < intervalsLen && intervals[i][0] <= newIntervalEnd)
        {
            newIntervalStart = Math.Min(newIntervalStart, intervals[i][0]);
            newIntervalEnd = Math.Max(newIntervalEnd, intervals[i][1]);
            i++;
        }
        
        result.Add(new int[] {newIntervalStart, newIntervalEnd});

        for(; i < intervals.Length; i++)
        {
            result.Add(intervals[i]);
        }
        
        return result.ToArray();
    }
}