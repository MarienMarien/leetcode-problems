public class MovingAverage {

    private Queue<int> _q;
    private int _capacity;
    private double _sum;
    private int _qSize { get { return _q.Count; } }
    public MovingAverage(int size)
    {
        _capacity = size;
        _q = new Queue<int>();
    }

    public double Next(int val)
    {
        if (_qSize == _capacity) {
            var toDelete = _q.Dequeue();
            _sum -= toDelete;
        }
        _q.Enqueue(val);
        _sum += val;
        return _sum / _qSize;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */