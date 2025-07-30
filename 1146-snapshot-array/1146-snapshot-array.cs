public class SnapshotArray {
    private IDictionary<int, Dictionary<int, int>> _arr;
    private int _snapId;
    public SnapshotArray(int length) {
        _arr = new Dictionary<int, Dictionary<int, int>>();
        for(var i = 0; i < length; i++)
        {
            _arr.Add(i, new Dictionary<int, int> { { 0, 0 } });
        }
    }
    
    public void Set(int index, int val) {
        _arr[index][_snapId] = val;
    }
    
    public int Snap() {
        _snapId++;
        return _snapId - 1;
    }
    
    public int Get(int index, int snap_id) {
        var element = _arr[index];
        if(element.ContainsKey(snap_id))
            return element[snap_id];
        var snaps = element.Keys.Order().ToList();
        var closestSnapId = GetClosestSnapId(snaps, snap_id);
        return element[closestSnapId];
    }
    
    private int GetClosestSnapId(IList<int> snaps, int snapId)
    {
        var start = 0;
        var end = snaps.Count - 1;
        var closestSnapId = -1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(snaps[mid] < snapId)
            {
                closestSnapId = mid;
                start = mid + 1;
            }
            else 
            {
                end = mid - 1;
            }
        }
        
        return snaps[closestSnapId];
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */