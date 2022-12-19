public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        if (source == destination)
            return true;
        var map = new Dictionary<int, ISet<int>>();
        foreach (var edge in edges) {
            if (!map.ContainsKey(edge[0]))
                map.Add(edge[0], new HashSet<int>());
            map[edge[0]].Add(edge[1]);
            if (!map.ContainsKey(edge[1]))
                map.Add(edge[1], new HashSet<int>());
            map[edge[1]].Add(edge[0]);
        }
        return HasPath(map, source, destination, new HashSet<int>());
    }

    private bool HasPath(Dictionary<int, ISet<int>> map, int source, int destination, HashSet<int> visited)
    {
        if (!map.ContainsKey(source))
            return false;
        if (map[source].Contains(destination))
            return true;
        if (!visited.Contains(source))
        {
            visited.Add(source);
            foreach (var s in map[source])
            {
                if (HasPath(map, s, destination, visited))
                    return true;
            }
        }
        return false;
    }
}