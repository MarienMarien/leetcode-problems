public class MyQueue {
    private ListNode _root;
    private int _count;
    private ListNode _curr;
    public MyQueue()
    {
        _root = new ListNode();
        _curr = _root;
        _count = 0;
    }

    public void Push(int x)
    {
        var newNode = new ListNode(x);
        _curr.next = newNode;
        _curr = _curr.next;
        _count++;
    }

    public int Pop()
    {
        var popped = _root.next.val;
        _root.next = _root.next.next;
        if(_root.next == null)
            _curr = _root;
        _count--;
        return popped;
    }

    public int Peek()
    {
        return _root.next == null ? 0 : _root.next.val;
    }

    public bool Empty()
    {
        return _count == 0;
    }

    private class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode()
        {
            this.val = 0;
            this.next = null;
        }
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
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