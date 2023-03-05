public class Solution {
    public int MinJumps(int[] arr) {
        if (arr.Length == 1)
            return 0;
        var map = new Dictionary<int, IList<int>>();
        for (var i = 0; i < arr.Length; i++)
        {
            map.TryAdd(arr[i], new List<int>());
            map[arr[i]].Add(i);
        }
        var visited = new bool[arr.Length];
        var q = new Queue<int>();
        q.Enqueue(0);
        var count = 0;
        var lastId = arr.Length - 1;
        while (q.Count > 0)
        {
            var size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var curr = q.Dequeue();
                if (curr == lastId)
                    return count;
                if (visited[curr])
                    continue;
                visited[curr] = true;
                var next = map[arr[curr]];
                if (curr - 1 >= 0)
                    next.Add(curr - 1);
                if (curr + 1 <= lastId)
                    next.Add(curr + 1);
                foreach (var id in map[arr[curr]])
                {
                    q.Enqueue(id);
                }
                next.Clear();
            }
            count++;
        }
        return arr.Length - 1;
    }
}