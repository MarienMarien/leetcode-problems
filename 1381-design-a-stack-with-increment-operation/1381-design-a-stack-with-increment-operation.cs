public class CustomStack {
    private int[] _stack;
    private int _currId;
    private int _capacity;

    public CustomStack(int maxSize)
    {
        _stack = new int[maxSize];
        _capacity = maxSize;
        _currId = 0;
    }

    public void Push(int x)
    {
        if (_currId == _capacity)
            return;
        _stack[_currId++] = x;
    }

    public int Pop()
    {
        if (_currId <= 0)
            return -1;
        
        _currId--;
        var poppedVal = _stack[_currId];
        
        return poppedVal;
    }

    public void Increment(int k, int val)
    {
        for (var i = 0; i < Math.Min(k, _capacity); i++)
        {
            _stack[i] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */