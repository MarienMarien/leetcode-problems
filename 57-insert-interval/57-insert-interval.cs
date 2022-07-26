public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var res = new List<int[]>();
        var newIntervalStartPos = 0;
        var isInserted = false;
        var isNewIntervalInserting = false;
        if (intervals.Length == 0 || newInterval[1] < intervals[0][0])
        {
            res.Add(newInterval);
            isInserted = true;
        }
        while (newIntervalStartPos < intervals.Length) {
            if (!isInserted && newInterval[0] <= intervals[newIntervalStartPos][1]) {
                newInterval[0] = Math.Min(intervals[newIntervalStartPos][0], newInterval[0]);
                isNewIntervalInserting = true;
            }
            if (isNewIntervalInserting)
            {
                if (newInterval[1] < intervals[newIntervalStartPos][0])
                {
                    res.Add(newInterval);
                    isNewIntervalInserting = false;
                    isInserted = true;
                }
                else {
                    newInterval[1] = Math.Max(newInterval[1], intervals[newIntervalStartPos][1]);
                }

            }
            if(!isNewIntervalInserting)
                res.Add(intervals[newIntervalStartPos]);
            newIntervalStartPos++;
        }
        if (!isInserted)
            res.Add(newInterval);

        return res.ToArray();
    }
}