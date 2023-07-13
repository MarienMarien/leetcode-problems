public class Solution {
    private IDictionary<int, ISet<int>> _map;
    private ISet<int> _visited;
    private ISet<int> _canFinish;
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        _map = new Dictionary<int, ISet<int>>();
        foreach(var p in prerequisites) {
            _map.TryAdd(p[0], new HashSet<int>());
            _map[p[0]].Add(p[1]);
        }
        _visited = new HashSet<int>();
        _canFinish = new HashSet<int>();
        for (var c = 0; c < numCourses; c++) {
            if (!CanFinishCourse(c)){
                return false;
            }
            _canFinish.Add(c);
        }
        return true;
    }

    private bool CanFinishCourse(int course)
    {
        if (!_map.ContainsKey(course) || _canFinish.Contains(course))
            return true;
        if (_visited.Contains(course))
            return false;
        _visited.Add(course);
        foreach (var c in _map[course]) {
            if (!CanFinishCourse(c))
                return false;
            _canFinish.Add(c);
        }
        return true;
    }
}