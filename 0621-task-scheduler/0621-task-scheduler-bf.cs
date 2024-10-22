public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var pq = new PriorityQueue<(char task, int interval), int>();
        var freq = new Dictionary<char, int>();
        foreach (var t in tasks)
        {
            if (!freq.TryAdd(t, 0))
            {
                freq[t]++;
            }
            var taskInterval = freq[t] == 0 ? 0 : freq[t] * n + freq[t];
            pq.Enqueue((t, taskInterval), taskInterval);
        }

        var count = 0;
        while (pq.Count > 0)
        {
            if (pq.Peek().interval <= count)
            {
                var curr = pq.Dequeue();
            }
            count++;
        }

        return count;
    }
}