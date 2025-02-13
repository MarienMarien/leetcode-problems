public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var indegree = new int[numCourses];
        var map = new Dictionary<int, ISet<int>>();
        foreach(var p in prerequisites)
        {
            indegree[p[0]]++;
            if(!map.TryAdd(p[1], new HashSet<int>{p[0]}))
                map[p[1]].Add(p[0]);
        }

        var q = new Queue<int>();
        var completedCount = 0;
        for(var i = 0; i < numCourses; i++)
        {
            if(indegree[i] == 0)
            {
                q.Enqueue(i);
                completedCount++;
            }
        }

        while(q.Count > 0)
        {
            var currCourse = q.Dequeue();
            if(!map.ContainsKey(currCourse))
                continue;
            foreach(var nextCourse in map[currCourse])
            {
                indegree[nextCourse]--;
                if(indegree[nextCourse] == 0)
                {
                    completedCount++;
                    q.Enqueue(nextCourse);
                }
            }
        }

        return completedCount == numCourses;
    }
}