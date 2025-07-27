public class RangeModule {
    private List<int[]> _ranges;

    public RangeModule() {
        _ranges = new List<int[]>();
    }
    
    public void AddRange(int left, int right) {
        var newInterval = new int[] { left, right };
        var id = 0;
        var newRanges = new List<int[]>();
        while(id < _ranges.Count && _ranges[id][1] < newInterval[0])
        {
            newRanges.Add(_ranges[id]);
            id++;
        }
        while(id < _ranges.Count && _ranges[id][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], _ranges[id][0]);
            newInterval[1] = Math.Max(newInterval[1], _ranges[id][1]);
            id++;
        }
        newRanges.Add(newInterval);
        for(; id < _ranges.Count; id++)
        {
            newRanges.Add(_ranges[id]);
        }
        _ranges = newRanges;
    }
    
    public bool QueryRange(int left, int right) {
        var start = 0;
        var end = _ranges.Count - 1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            var currRange = _ranges[mid];
            if(currRange[0] >= right)
            {
                end = mid - 1;
            } 
            else if(currRange[1] <= left)
            {
                start = mid + 1;
            } 
            else 
            {
                return currRange[0] <= left && right <= currRange[1];
            }
        }
        return false;
    }
    
    public void RemoveRange(int left, int right) {
        var n = _ranges.Count;
        var updatedRanges = new List<int[]>();
        for(var i = 0; i < n; i++)
        {
            var currRange = _ranges[i];
            if(right < currRange[0] || currRange[1] < left)
            {
                updatedRanges.Add(currRange);
                continue;
            }

            if(currRange[0] < left)
            {
                updatedRanges.Add(new int[] { currRange[0], left });

            }
            if(right < currRange[1])
            {
                updatedRanges.Add(new int[] { right, currRange[1] });
            }
        }

        _ranges = updatedRanges;
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */