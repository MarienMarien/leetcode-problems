public class MyCircularDeque {

    private int _maxCapacity;
    private DoublyLinkedListNode _head;
    private DoublyLinkedListNode _tail;
    private int _capacity;
    public MyCircularDeque(int k)
    {
        _maxCapacity = k;
        _head = new DoublyLinkedListNode();
        _tail = new DoublyLinkedListNode(0, null, _head);
        _head.Next = _tail;
    }

    public bool InsertFront(int value)
    {
        if (_capacity >= _maxCapacity)
            return false;

        _capacity++;
        var newNode = new DoublyLinkedListNode(value, _head.Next, _head);
        var nextNode = _head.Next;
        nextNode.Prev = newNode;
        _head.Next = newNode;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (_capacity >= _maxCapacity)
            return false;

        _capacity++;
        var newNode = new DoublyLinkedListNode(value, _tail, _tail.Prev);
        var prevNode = _tail.Prev;
        prevNode.Next = newNode;
        _tail.Prev = newNode;
        return true;
    }

    public bool DeleteFront()
    {
        if (_capacity == 0)
            return false;

        _capacity--;
        var newFirst = _head.Next;
        _head = newFirst;
        newFirst.Prev = _head;
        return true;
    }

    public bool DeleteLast()
    {
        if (_capacity == 0)
            return false;

        _capacity--;
        var newLast = _tail.Prev.Prev;
        newLast.Next = _tail;
        _tail.Prev = newLast;
        return true;
    }

    public int GetFront()
    {
        return _capacity == 0 ? -1 :_head.Next.Val;
    }

    public int GetRear()
    {
        return _capacity == 0 ? -1 :_tail.Prev.Val;
    }

    public bool IsEmpty()
    {
        return _capacity == 0;
    }

    public bool IsFull()
    {
        return _capacity == _maxCapacity;
    }
}

public class DoublyLinkedListNode
{
    public DoublyLinkedListNode Next;
    public DoublyLinkedListNode Prev;
    public int Val;

    public DoublyLinkedListNode(int value = 0, DoublyLinkedListNode next = null, DoublyLinkedListNode prev = null)
    {
        this.Val = value;
        this.Next = next;
        this.Prev = prev;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */