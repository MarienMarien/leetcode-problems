public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var components = new Dictionary<int, HashSet<int>>();
        foreach (var e in edges) {
            if (!components.ContainsKey(e[0]))
                components.Add(e[0], new HashSet<int>());
            components[e[0]].Add(e[1]);
            if (!components.ContainsKey(e[1]))
                components.Add(e[1], new HashSet<int>());
            components[e[1]].Add(e[0]);
        }
        var visited = new HashSet<int>();
        var count = 0;
        for (var i = 0; i < n; i++) {
            if (!visited.Contains(i)) { 
                visited.Add(i);
                if(components.ContainsKey(i))
                    Dfs(components, i, visited);
                count++;
            }
        }
        return count;
    }

    private void Dfs(Dictionary<int, HashSet<int>> components, int i, HashSet<int> visited)
    {
        foreach (var el in components[i]) { 
            if (!visited.Contains(el))
            {
                visited.Add(el);
                Dfs(components, el, visited);
            }
        }
    }
}