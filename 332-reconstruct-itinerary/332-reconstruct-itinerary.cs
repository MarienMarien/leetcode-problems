public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
         var startAirport = "JFK";
        // build flight map
        var flightMap = new Dictionary<string, Queue<string>>();
        foreach (var ticket in tickets)
        {
            var from = ticket[0];
            var to = ticket[1];
            if (!flightMap.ContainsKey(from))
            {
                var children = new Queue<string>();
                flightMap.Add(ticket[0], children);
            }
            flightMap[from].Enqueue(to);
        }

        foreach (var key in flightMap.Keys)
        {
            flightMap[key] = new Queue<string>(flightMap[key].OrderBy(x => x));
        }

        var currRes = new List<string>();
        GetItinerary(flightMap, startAirport, currRes);
        currRes.Reverse();
        return currRes;
    }

    public void GetItinerary(Dictionary<string, Queue<string>> flightMap, string currentAirport, IList<string> itinerary)
    {
        flightMap.TryGetValue(currentAirport, out Queue<string> destinations);
        while (destinations != null && destinations.Count > 0) {
            var next = destinations.Dequeue();
            GetItinerary(flightMap, next, itinerary);
        }
        itinerary.Add(currentAirport);
    }
}