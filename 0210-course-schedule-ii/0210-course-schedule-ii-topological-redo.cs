public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var indegree = new int[numCourses];
        var graph = new Dictionary<int, ISet<int>>();
        foreach(var p in prerequisites)
        {
            if(!graph.TryAdd(p[1], new HashSet<int> { p[0] }))
                graph[p[1]].Add(p[0]);
            indegree[p[0]]++;
        }

        var q = new Queue<int>();
        for(var i = 0; i < numCourses; i++)
        {
            if(indegree[i] == 0)
                q.Enqueue(i);
        }
        var answer = new int[numCourses];
        var ansId = 0;
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            answer[ansId] = curr;
            ansId++;
            if(!graph.ContainsKey(curr))
                continue;
            foreach(var adj in graph[curr])
            {
                indegree[adj]--;
                if(indegree[adj] == 0)
                    q.Enqueue(adj);
            }
        }

        return ansId == numCourses ? answer : Array.Empty<int>();
    }
}