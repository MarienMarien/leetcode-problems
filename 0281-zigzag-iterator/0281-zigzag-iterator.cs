public class ZigzagIterator {
    private DoublyLinkedNode _currentList;
    private int _index;
    private int _count;
    public ZigzagIterator(IList<int> v1, IList<int> v2)
    {
        if (v1 != null && v1.Count > 0) { 
            _currentList = new DoublyLinkedNode(v1);
            _currentList.next = _currentList;
            _currentList.prev = _currentList;
        }
        if (v2 != null && v2.Count > 0)
        {
            var second = new DoublyLinkedNode(v2);
            if (_currentList == null)
            {
                _currentList = second;
                _currentList.next = _currentList;
                _currentList.prev = _currentList;
            }
            else
            {
                _currentList.next = second;
                _currentList.prev = second;
                second.prev = _currentList;
                second.next = _currentList;
            }
        }

        _count = v1.Count + v2.Count;
        _index = 0;
    }

    public bool HasNext()
    {
        return _index < _count;
    }

    public int Next()
    {
        _index++;
        var nextVal = _currentList.GetCurrNumber();
        if (!_currentList.HasNext()) {
            _currentList.prev.next = _currentList.next;
            _currentList.next.prev = _currentList.prev;
        }
        _currentList = _currentList.next;
        return nextVal;
    }

    private class DoublyLinkedNode {
        public IList<int> val;
        private int currId;
        public DoublyLinkedNode next;
        public DoublyLinkedNode prev;

        public DoublyLinkedNode(IList<int> value, DoublyLinkedNode prev = null, DoublyLinkedNode next = null)
        {
            this.val = value;
            this.currId = 0;
            this.prev= prev;
            this.next = next;
        }

        public int GetCurrNumber()
        {
            return val[currId++];
        }

        public bool HasNext() { 
            return currId < val.Count;
        }
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */