public class Solution {
    public int MaxTwoEvents(int[][] events) {
        var times = new List<(int time, int type, int value)>(events.Length * 2);
        foreach (var e in events)
        {
            times.Add((e[0], 1, e[2]));
            times.Add((e[1] + 1, 0, e[2]));
        }

        times = times.OrderBy(t => t, Comparer<(int time, int type, int val)>
            .Create((x, y) => x.time == y.time ? x.type.CompareTo(y.type) : x.time.CompareTo(y.time)))
            .ToList();
        var ans = 0;
        var maxVal = 0;

        foreach (var t in times)
        {
            if (t.type == 1)
            {
                ans = Math.Max(ans, t.value + maxVal);
            }
            else {
                maxVal = Math.Max(maxVal, t.value);
            }
        }

        return ans;
    }
}