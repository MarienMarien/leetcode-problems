public class Solution {
    public int FindChampion(int n, int[][] edges) {
        var nodesMap = new Dictionary<int, ISet<int>>();
        foreach(var e in edges)
        {
            if(!nodesMap.TryAdd(e[1], new HashSet<int>{e[0]}))
                nodesMap[e[1]].Add(e[0]);
        }

        var champion = -1;
        for(var team = 0; team < n; team++)
        {
            if(!nodesMap.ContainsKey(team))
            {
                if(champion != -1)
                    return -1;
                champion = team;
            }
        }
        return champion;
    }
}