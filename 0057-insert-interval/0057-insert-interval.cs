public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var result = new List<int[]>();
        var id = 0;
        var inserted = false;
        while(id < intervals.Length) {
            if (!inserted && newInterval[0] <= intervals[id][1]) {
                if (newInterval[1] < intervals[id][0]) {
                    result.Add(newInterval);
                    inserted = true;
                    continue;
                }
                var newEntry = new int[2];
                newEntry[0] = Math.Min(intervals[id][0], newInterval[0]);
                newEntry[1] = Math.Max(newInterval[1], intervals[id][1]);
                id++;
                while (id < intervals.Length && intervals[id][0] <= newEntry[1]) {
                    newEntry[1] = Math.Max(newEntry[1], intervals[id][1]);
                    id++;
                }
                result.Add(newEntry);
                inserted = true;
                continue;
            }
            result.Add(intervals[id]);
            id++;
        }
        if (!inserted)
            result.Add(newInterval);
        return result.ToArray();
    }
}