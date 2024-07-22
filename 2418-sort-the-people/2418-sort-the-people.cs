public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        for (var i = 0; i < heights.Length; i++)
        {
            pq.Enqueue(i, heights[i]);
        }

        var ans = new string[names.Length];
        for (var i = 0; i < names.Length; i++)
        {
            var currId = pq.Dequeue();
            ans[i] = names[currId];
        }

        return ans;
    }
}