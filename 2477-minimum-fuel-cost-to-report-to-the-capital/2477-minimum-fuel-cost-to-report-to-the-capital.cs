public class Solution {
    private long _fuel;
    public long MinimumFuelCost(int[][] roads, int seats)
    {
        var roadMap = new Dictionary<int, HashSet<int>>();
        foreach (var r in roads) {
            if(!roadMap.TryAdd(r[0], new HashSet<int>() { r[1] }))
                roadMap[r[0]].Add(r[1]);
            if(!roadMap.TryAdd(r[1], new HashSet<int>() { r[0] }))
                roadMap[r[1]].Add(r[0]);
        }
        CountFuel(0, -1, roadMap, seats);
        return _fuel;
    }

    private long CountFuel(int currCity, int prevCity, Dictionary<int, HashSet<int>> roadMap, int seats)
    {
        long riders = 1;
        if (!roadMap.ContainsKey(currCity))
            return riders;
        foreach (var city in roadMap[currCity]) {
            if (city != prevCity)
                riders += CountFuel(city, currCity, roadMap, seats);
        }
        if (currCity != 0)
            _fuel += (long)Math.Ceiling((double)riders / seats);
        return riders;
    }
}