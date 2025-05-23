public class FirstUnique {
    private IDictionary<int, ListNode> _listMap;
    private ListNode _head;
    private ListNode _tail;

    public FirstUnique(int[] nums)
    {
        _listMap = new Dictionary<int, ListNode>();
        _head = new ListNode();
        _tail = new ListNode(0, _head);
        _head.Next = _tail;

        foreach (var n in nums)
        {
            if (_listMap.ContainsKey(n))
            {
                RemoveNode(n);
                continue;
            }

            var prevNode = _tail.Prev;
            var newNode = new ListNode(n, prevNode, _tail);
            prevNode.Next = newNode;
            _tail.Prev = newNode;
            _listMap.Add(n, newNode);
        }
    }

    public int ShowFirstUnique()
    {
        return _head.Next == _tail ? -1 : _head.Next.Value;
    }

    public void Add(int value)
    {
        if (_listMap.ContainsKey(value))
        {
            RemoveNode(value);
            return;
        }

        var prevNode = _tail.Prev;
        var newNode = new ListNode(value, prevNode, _tail);
        prevNode.Next = newNode;
        _tail.Prev = newNode;
        _listMap.Add(value, newNode);
    }

    private void RemoveNode(int n)
    {
        if (_listMap[n] == null)
            return;

        var currPrev = _listMap[n].Prev;
        var newNext = _listMap[n].Next;
        currPrev.Next = newNext;
        newNext.Prev = currPrev;

        _listMap[n] = null;
    }
}

public class ListNode 
{
    public int Value;
    public ListNode Next;
    public ListNode Prev;

    public ListNode(int value = 0, ListNode prev = null, ListNode next = null)
    {
        Value = value;
        Next = next;
        Prev = prev; 
    }
}

/**
 * Your FirstUnique object will be instantiated and called as such:
 * FirstUnique obj = new FirstUnique(nums);
 * int param_1 = obj.ShowFirstUnique();
 * obj.Add(value);
 */