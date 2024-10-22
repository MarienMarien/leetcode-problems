public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var freq = new Dictionary<char, int>();
        var intervals = new int[tasks.Length];
        for(var i = 0; i < tasks.Length; i++)
        {
            if (!freq.TryAdd(tasks[i], 0))
            {
                freq[tasks[i]]++;
            }
            var taskInterval = freq[tasks[i]] == 0 ? 0 : freq[tasks[i]] * n + freq[tasks[i]];
            intervals[i] = taskInterval;
        }
        Array.Sort(intervals);

        var count = 0;
        for (var i = 0; i < intervals.Length; i++)
        {
            if (intervals[i] > count)
            {
                count += intervals[i] - count + 1;
            }
            else {
                count++;
            }
        }

        return count;
    }
}