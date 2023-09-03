public class SmallestInfiniteSet {

    private ISet<int> _set;
    private PriorityQueue<int, int> _pq;
    private int _latestPopped;
    public SmallestInfiniteSet()
    {
        _set = new HashSet<int> { 1 };
        _pq= new PriorityQueue<int, int>();
        _pq.Enqueue(1, 1);
    }

    public int PopSmallest()
    {
        var popped = _pq.Dequeue();
        if(popped >= _latestPopped)
            _latestPopped = popped;
        _set.Remove(popped);
        var nextSmallest = _latestPopped + 1;
        if (!_set.Contains(nextSmallest)) { 
            _set.Add(nextSmallest);
            _pq.Enqueue(nextSmallest, nextSmallest);
        }
        return popped;
    }

    public void AddBack(int num)
    {
        if (_set.Contains(num))
            return;
        _set.Add(num);
        _pq.Enqueue(num, num);
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */