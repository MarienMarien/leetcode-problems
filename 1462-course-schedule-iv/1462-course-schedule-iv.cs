public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var graph = new Dictionary<int, ISet<int>>();
        foreach (var pr in prerequisites)
        {
            if (!graph.TryAdd(pr[0], new HashSet<int> { pr[1] }))
                graph[pr[0]].Add(pr[1]);
        }

        var prerequisiteTable = new bool[numCourses,numCourses];
        for (var course = 0; course < numCourses; course++)
        {
            var q = new Queue<int>();
            q.Enqueue(course);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                if(!graph.ContainsKey(curr))
                    continue;
                foreach (var c in graph[curr])
                {
                    if (!prerequisiteTable[course,c])
                    {
                        prerequisiteTable[course, c] = true;
                        q.Enqueue(c);
                    }
                }
            }
        }

        var res = new List<bool>();
        foreach (var q in queries)
        {
            res.Add(prerequisiteTable[q[0], q[1]]);
        }

        return res;
    }
}