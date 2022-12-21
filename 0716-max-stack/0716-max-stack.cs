public class MaxStack {
    private DoublyLinkedListNode _head;
    private DoublyLinkedListNode _tail;
    private SortedDictionary<int, Stack<DoublyLinkedListNode>> _heap;
    
    public MaxStack()
    {
        _head = new DoublyLinkedListNode();
        _tail = _head;
        _heap = new SortedDictionary<int, Stack<DoublyLinkedListNode>>(Comparer<int>.Create((x, y) => { return y - x; }));
    }

    public void Push(int x)
    {
        var newNode = new DoublyLinkedListNode(x, _tail);
        _heap.TryAdd(x, new Stack<DoublyLinkedListNode>());
        _heap[x].Push(newNode);
        _tail.next = newNode;
        _tail = _tail.next;
    }

    public int Pop()
    {
        if (_tail.prev == null)
            return Int32.MinValue;
        var popped = _tail;
        _tail.prev.next = _tail.next;
        _tail = _tail.prev;
        _heap[popped.val].Pop();
        if (_heap[popped.val].Count == 0)
            _heap.Remove(popped.val);
        return popped.val;
    }

    public int Top()
    {
        return _tail.val;
    }

    public int PeekMax()
    {
        return _heap.First().Value.Peek().val;
    }

    public int PopMax()
    {
        var first = _heap.First();
        var popped = first.Value.Pop();
        if (first.Value.Count == 0)
            _heap.Remove(first.Key);
        popped.prev.next = popped.next;
        if(popped.next != null)
            popped.next.prev = popped.prev;
        if (_tail == popped)
            _tail = _tail.prev;
        return popped.val;
    }

    private class DoublyLinkedListNode
    {
        public int val;
        public DoublyLinkedListNode prev;
        public DoublyLinkedListNode next;

        public DoublyLinkedListNode(int val = 0, DoublyLinkedListNode prev = null, DoublyLinkedListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */