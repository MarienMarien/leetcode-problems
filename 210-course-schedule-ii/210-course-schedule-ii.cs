public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var order = new List<int>();
            var coursePrereqMap = new Dictionary<int, int>();
            for (var i = 0; i < numCourses; i++)
            {
                coursePrereqMap.Add(i, 0);
            }

            for (var i = 0; i < prerequisites.Length; i++)
            {
                coursePrereqMap[prerequisites[i][0]]++;
            }
            order.AddRange(coursePrereqMap.Where(x => x.Value == 0).Select(x => x.Key));
            var q = new Queue<int>(order);

            while (q.Count > 0) {
                var prerequisite = q.Dequeue();
                for (var i = 0; i < prerequisites.Length; i++) {
                    var curr = prerequisites[i];
                    if (curr[1] == prerequisite) {
                        var currPrereq = prerequisites[i][0];
                        coursePrereqMap[currPrereq]--;
                        if (coursePrereqMap[currPrereq] == 0) {
                            order.Add(currPrereq);
                            q.Enqueue(currPrereq);
                        }
                    }
                }
            }


            return coursePrereqMap.Any(x => x.Value > 0) ? Array.Empty<int>() : order.ToArray();
    }
}