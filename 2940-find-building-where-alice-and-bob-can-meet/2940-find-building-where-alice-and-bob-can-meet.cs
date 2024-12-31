public class Solution {
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries) {
        var qList = new List<List<List<int>>>(heights.Length);
        for (var i = 0; i < heights.Length; i++) 
            qList.Add(new List<List<int>>());
        var maxId = new PriorityQueue<List<int>, int>();
        var res = new int[queries.Length];
        Array.Fill(res, -1);

        for (var currQ = 0; currQ < queries.Length; currQ++)
        {
            var a = queries[currQ][0];
            var b = queries[currQ][1];
            if (a < b && heights[a] < heights[b])
            {
                res[currQ] = b;
            }
            else if (a > b && heights[a] > heights[b])
            {
                res[currQ] = a;
            }
            else if (a == b)
            {
                res[currQ] = a;
            }
            else
            {
                var qListId = Math.Max(a, b);
                qList[qListId]
                    .Add(new List<int> { Math.Max(heights[a], heights[b]), currQ });
            }
        }

        for (var i = 0; i < heights.Length; i++)
        {
            while (maxId.Count > 0 && maxId.Peek()[0] < heights[i])
            {
                res[maxId.Peek()[1]] = i;
                maxId.Dequeue();
            }

            foreach (var element in qList[i])
            {
                maxId.Enqueue(element, element[0]);
            }
        }
        return res;
    }
}