public class UndergroundSystem {

    private Dictionary<int, (string station, int time)> _checkIns;
    private Dictionary<string, AvgData> _trips;

    public UndergroundSystem()
    {
        _checkIns = new Dictionary<int, (string station, int time)>();
        _trips = new Dictionary<string, AvgData>();
    }

    public void CheckIn(int id, string stationName, int t)
    {
        if (!_checkIns.ContainsKey(id))
            _checkIns.Add(id, (station: stationName, time: t));
        _checkIns[id] = (station: stationName, time: t);
    }

    public void CheckOut(int id, string stationName, int t)
    {
        if (!_checkIns.ContainsKey(id))
            throw new KeyNotFoundException();
        var newKey = $"{_checkIns[id].station}-{stationName}";
        var isTripExist = _trips.TryGetValue(newKey, out AvgData avgData);
        var tripTime = t - _checkIns[id].time;
        if (!isTripExist)
        {
            avgData = new AvgData();
            _trips.Add(newKey, avgData);
        }
        avgData.AddTrip(tripTime);
        
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        var key = $"{startStation}-{endStation}";
        if (!_trips.ContainsKey(key))
            return 0;
        return _trips[key].AverageTime;
    }

    private class AvgData { 
        public double AverageTime { get; set; }
        private int TripsCount { get; set; }
        private long TotalTime { get; set; }
        public AvgData()
        {
            AverageTime = 0;
            TripsCount = 0;
        }
        public void AddTrip(int time) {
            this.TripsCount++;
            this.TotalTime += time;
            this.AverageTime = (double)this.TotalTime / this.TripsCount;
        }
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */