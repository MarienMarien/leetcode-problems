public class LRUCache {

    private Dictionary<int, Node> _cache;
    private Node _head;
    private Node _tail;
    private int _capacity;

    private void AddNode(Node node)
    {
        node.Prev = _head;
        node.Next = _head.Next;
        _head.Next.Prev = node;
        _head.Next = node;
    }

    private void RemoveNode(Node node)
    {
        var prev = node.Prev;
        var next = node.Next;

        prev.Next = next;
        next.Prev = prev;
    }

    public LRUCache(int capacity)
    {
        _cache = new Dictionary<int, Node>();
        _capacity = capacity;
        _head = new Node();
        _tail = new Node();
        _head.Next = _tail;
        _tail.Next = _head;
    }

    public int Get(int key)
    {
        var val = -1;
        if (_cache.ContainsKey(key))
        {
            var node = _cache[key];
            val = node.Value;
            RemoveNode(node);
            AddNode(node);
        }
        return val;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            var node = _cache[key];
            RemoveNode(node);
            node.Value = value;
            AddNode(node);

        }
        else
        {
            var newNode = new Node(key, value);
            if (_cache.Count == _capacity)
            {
                _cache.Remove(_tail.Prev.Key);
                RemoveNode(_tail.Prev);

            }
            AddNode(newNode);
            _cache.Add(key, newNode);
        }
    }

    class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }
        public Node() { }

        public Node(int key, int value, Node prev = null, Node next = null)
        {
            Key = key;
            Value = value;
            Prev = prev;
            Next = next;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */