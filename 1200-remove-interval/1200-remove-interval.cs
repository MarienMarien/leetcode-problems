public class Solution {
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved) {
        var res = new List<IList<int>>();

        foreach (var interval in intervals)
        {
            if (interval[1] <= toBeRemoved[0] || interval[0] >= toBeRemoved[1] )
            { 
                res.Add(interval.ToList());
            }

            if (interval[1] <= toBeRemoved[1] && interval[1] >= toBeRemoved[0])
            {
                if (interval[0] < toBeRemoved[0])
                {
                    res.Add(new List<int> { interval[0], toBeRemoved[0] });
                }
            }

            if (interval[0] >= toBeRemoved[0] && interval[0] <= toBeRemoved[1])
            {
                if (interval[1] > toBeRemoved[1])
                {
                    res.Add(new List<int> { toBeRemoved[1], interval[1] });
                }
            }

            if (interval[0] < toBeRemoved[0] && interval[1] > toBeRemoved[1])
            {
                res.Add(new List<int> { interval[0], toBeRemoved[0] });
                res.Add(new List<int> { toBeRemoved[1], interval[1]});
            }
        }

        return res;
    }
}