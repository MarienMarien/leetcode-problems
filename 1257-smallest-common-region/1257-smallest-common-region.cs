public class Solution {
    public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2) {
        if (region1.Equals(region2))
            return region1;

        var map = new Dictionary<string, ISet<string>>();
        foreach (var r in regions)
        {
            var main = r[0];
            for (var i = 1; i < r.Count; i++)
            {
                if (!map.TryAdd(r[i], new HashSet<string> { main }))
                    map[r[i]].Add(main);
            }
        }
        var region1Paths = GetGreaterRegions(region1, map);
        var region1ConnectedTo = new HashSet<string>(region1Paths);
        var region2Paths = GetGreaterRegions(region2, map);
        var currRegion = string.Empty;
        while (region2Paths.Count > 0 && region1ConnectedTo.Contains(region2Paths.Peek()))
        {
            currRegion = region2Paths.Pop();
        }
        return currRegion;
    }

    private Stack<string> GetGreaterRegions(string region, Dictionary<string, ISet<string>> map)
    {
        var q = new Queue<string>();
        q.Enqueue(region);
        var stack = new Stack<string>();
        stack.Push(region);
        
        while (q.Count > 0)
        {
            var currRegion = q.Dequeue();
            if (!map.ContainsKey(currRegion))
                continue;
            foreach (var r in map[currRegion])
            {
                q.Enqueue(r);
                stack.Push(r);
            }
        }

        return stack;
    }
}