public class MyQueue {
    private Stack<int> _stack1;
    private Stack<int> _stack2;
    private int _top;

    public MyQueue() {
        _stack1 = new Stack<int>();
        _stack2 = new Stack<int>();
    }
    
    public void Push(int x) {
        if(_stack1.Count == 0)
            _top = x;
        _stack1.Push(x);
    }
    
    public int Pop() {
        if(_stack2.Count == 0)
        {
            while(_stack1.Count > 0)
                _stack2.Push(_stack1.Pop());
        }
        return _stack2.Pop();
    }
    
    public int Peek() {
        if(_stack2.Count == 0)
            return _top;
        return _stack2.Peek();
    }
    
    public bool Empty() {
        return _stack1.Count == 0 && _stack2.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */