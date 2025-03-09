public class Solution {
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved) {
        var result = new List<IList<int>>();
        var remRangeStart = toBeRemoved[0];
        var remRangeEnd = toBeRemoved[1];
        for(var i = 0; i < intervals.Length; i++)
        {
            var currInterval = intervals[i];
            var currStart = currInterval[0];
            var currEnd = currInterval[1];
            if(remRangeStart <= currStart && currEnd <= remRangeEnd)
            {
                continue;
            }
            if(remRangeEnd <= currStart || currEnd <= remRangeStart)
            {
                result.Add(currInterval.ToList());
                continue;
            }

            if(currStart < remRangeStart && remRangeStart < remRangeEnd)
            {
                result.Add(new List<int> { currStart, remRangeStart });
            }

            if(currStart < remRangeEnd && remRangeEnd < currEnd)
            {
                result.Add(new List<int> { remRangeEnd, currEnd });
            }
        }

        return result;
    }
}