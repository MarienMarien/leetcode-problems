public class Solution {
    private ISet<int> _visited;
    private ISet<int> _processed;
    private Stack<int> _stack;
    private IDictionary<int, ISet<int>> _graph;
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        _graph = new Dictionary<int, ISet<int>>();
        foreach(var p in prerequisites)
        {
            if(!_graph.TryAdd(p[1], new HashSet<int> { p[0] }))
                _graph[p[1]].Add(p[0]);
        }
        
        _visited = new HashSet<int>(); 
        _stack = new Stack<int>(); 
        _processed = new HashSet<int>();
        for(var course = 0; course < numCourses; course++)
        {
            if(!_visited.Contains(course) && !CheckOrder(course))
                 return Array.Empty<int>();
        }

        var answer = new int[numCourses];
        for(var i = 0; i < numCourses; i++)
        {
            answer[i] = _stack.Pop();
        }
        return answer;
    }

    private bool CheckOrder(int course)
    {
        _visited.Add(course);
        if(_graph.ContainsKey(course))
        {
            foreach(var adj in _graph[course])
            {
                if(_visited.Contains(adj) && !_processed.Contains(adj))
                    return false;
                if(!_visited.Contains(adj) && !CheckOrder(adj))
                    return false;
            }
        }
        _processed.Add(course);
        _stack.Push(course);
        return true;
    }
}