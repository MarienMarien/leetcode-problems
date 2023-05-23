public class KthLargest {
    private int _k;
    private PriorityQueue<int, int> _pq;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _pq = new PriorityQueue<int, int>();
        foreach (int n in nums)
        {
            if (_pq.Count < _k || n > _pq.Peek()) {
                _pq.Enqueue(n, n);
            }
            if (_pq.Count > _k)
                _pq.Dequeue();
        }
    }

    public int Add(int val)
    {
        if(_pq.Count == _k && _pq.Peek() > val)
            return _pq.Peek();
        _pq.Enqueue(val, val);
        if (_pq.Count > _k)
        {
            _pq.Dequeue();
        }
        return _pq.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */