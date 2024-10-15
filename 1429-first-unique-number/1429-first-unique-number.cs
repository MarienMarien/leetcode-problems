public class FirstUnique {
    private IDictionary<int, int> _freq;
    private Queue<int> _queue;

    public FirstUnique(int[] nums)
    {
        _queue = new Queue<int>();
        _freq = new Dictionary<int, int>();

        foreach (var n in nums) {
            if (_freq.ContainsKey(n))
            {
                _freq[n]++;
                continue;
            }
            _freq.Add(n, 1);
            _queue.Enqueue(n);
        }
    }

    public int ShowFirstUnique()
    {
        while (_queue.Count > 0 && _freq[_queue.Peek()] > 1)
            _queue.Dequeue();
        return _queue.Count > 0 ? _queue.Peek() : -1;
    }

    public void Add(int value)
    {
        if (_freq.ContainsKey(value))
        {
            _freq[value]++;
            return;
        }

        _freq.Add(value, 1);
        _queue.Enqueue(value);
    }
}

/**
 * Your FirstUnique object will be instantiated and called as such:
 * FirstUnique obj = new FirstUnique(nums);
 * int param_1 = obj.ShowFirstUnique();
 * obj.Add(value);
 */