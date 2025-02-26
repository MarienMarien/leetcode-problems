public class MedianFinder {
    private PriorityQueue<int, int> _right;// min heap
    private PriorityQueue<int, int> _left;// max heap

    public MedianFinder() {
        _right = new PriorityQueue<int, int>();
        _left = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
    }
    
    public void AddNum(int num) {
        if(_right.Count > 0 && num > _right.Peek())
            _right.Enqueue(num, num);
        else
            _left.Enqueue(num, num);
        
        if(_right.Count > _left.Count + 1)
        {
            var val = _right.Dequeue();
            _left.Enqueue(val, val);
        } 
        else if(_left.Count > _right.Count + 1)
        {
            var val = _left.Dequeue();
            _right.Enqueue(val, val);
        }
    }
    
    public double FindMedian() {
        if(_right.Count == _left.Count)
            return (_right.Peek() + _left.Peek()) / 2d;
        return _right.Count > _left.Count ? _right.Peek() : _left.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */