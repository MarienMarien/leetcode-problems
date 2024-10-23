public class LRUCache {
    private int _capacity;
    private IDictionary<int, DoublyLinkedListNode> _nodeMap;
    private DoublyLinkedListNode _head;
    private DoublyLinkedListNode _tail;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _nodeMap = new Dictionary<int, DoublyLinkedListNode>();
        _head = new DoublyLinkedListNode(-1, -1);
        _tail = new DoublyLinkedListNode(-1, -1, _head);
        _head.next = _tail;
    }

    public int Get(int key)
    {
        if (!_nodeMap.ContainsKey(key))
            return -1;
        var updatedNode = MoveNodeToHead(key);
        _nodeMap[key] = updatedNode;
        return updatedNode.val;
    }

    public void Put(int key, int value)
    {
        AddOrUpdateNode(key, value);
        if (_nodeMap.Count > _capacity)
        {
            Evict();
        }
    }

    private void AddOrUpdateNode(int key, int value)
    {
        if (_nodeMap.ContainsKey(key))
        {
            _nodeMap[key].val = value;
            var updatedNode = MoveNodeToHead(key);
            _nodeMap[key] = updatedNode;
            return;
        }

        var newNode = new DoublyLinkedListNode(key, value, _head, _head.next);
        var prevFirst = _head.next;
        prevFirst.prev = newNode;
        _head.next = newNode;
        _nodeMap.Add(key, newNode);
    }

    private void Evict()
    {
        var prevLast = _tail.prev;
        var newLast = prevLast.prev;
        newLast.next = _tail;
        _tail.prev = newLast;
        _nodeMap.Remove(prevLast.key);
    }

    private DoublyLinkedListNode MoveNodeToHead(int key)
    {
        var node = _nodeMap[key];
        var prev = node.prev;
        prev.next = node.next;
        var next = node.next;
        next.prev = prev;

        node.prev = _head;
        node.next = _head.next;
        var prevFirst = _head.next;
        prevFirst.prev = node;
        _head.next = node;
        return node;
    }
}

public class DoublyLinkedListNode
{
    public int key;
    public int val;
    public DoublyLinkedListNode next;
    public DoublyLinkedListNode prev;

    public DoublyLinkedListNode(int key = -1, int val = -1, DoublyLinkedListNode prev = null, DoublyLinkedListNode next = null)
    {
        this.key = key;
        this.val = val;
        this.prev = prev;
        this.next = next;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */