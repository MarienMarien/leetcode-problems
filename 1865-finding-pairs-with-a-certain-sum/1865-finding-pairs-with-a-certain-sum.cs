public class FindSumPairs {
    private IDictionary<int, int> _num1Map;
    private IDictionary<int, int> _num2Map;
    private int[] _nums2;
    public FindSumPairs(int[] nums1, int[] nums2) {
        _nums2 = nums2;
        _num1Map = new Dictionary<int, int>();
        _num2Map = new Dictionary<int, int>();
        foreach(var n in nums1)
        {
            if(!_num1Map.TryAdd(n, 1))
                _num1Map[n]++;
        }
        foreach(var n in nums2)
        {
            if(!_num2Map.TryAdd(n, 1))
                _num2Map[n]++;
        }
    }
    
    public void Add(int index, int val) {
        var keyToAdj = _nums2[index];
        _num2Map[keyToAdj]--;
        if(_num2Map[keyToAdj] == 0)
            _num2Map.Remove(keyToAdj);
        _nums2[index] += val;
        var newKey = _nums2[index];
        if(!_num2Map.TryAdd(newKey, 1))
            _num2Map[newKey]++;
    }
    
    public int Count(int tot) {
        var count = 0;
        foreach(var n in _num1Map)
        {
            var complementary = tot - n.Key;
            if(!_num2Map.ContainsKey(complementary))
                continue;
            count += n.Value * _num2Map[complementary];
        }

        return count;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */