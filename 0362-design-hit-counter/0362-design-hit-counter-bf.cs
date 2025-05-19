public class HitCounter {
    private IList<(int totalHits, int timestamp)> _hits;
    public HitCounter() {
        _hits = new List<(int totalHits, int timestamp)>();
    }
    
    public void Hit(int timestamp) {
        var hitsCountSoFar = _hits.Count == 0 ? 1 : _hits[^1].totalHits + 1;
        _hits.Add((hitsCountSoFar, timestamp));
    }
    
    public int GetHits(int timestamp) {
        if(_hits.Count == 0)
            return 0;
        var tStart = timestamp - 300;
        var tEnd = timestamp;
        if(tStart <= 0)
            return _hits[^1].totalHits;
        var startHitsCount = GetStartHitsCount(tStart);
        return _hits[^1].totalHits - startHitsCount; 
    }

    private int GetStartHitsCount(int tStart)
    {
        var start = 0;
        var end = _hits.Count - 1;
        var startHits = -1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(_hits[mid].timestamp <= tStart)
            {
                startHits = mid;
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }

        return startHits == -1 ? 0 : _hits[startHits].totalHits;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */