public class BrowserHistory {

    private DoublyLinkedListNode<string> _history;
    private DoublyLinkedListNode<string> _curr;
    public BrowserHistory(string homepage)
    {
        _history = new DoublyLinkedListNode<string>(homepage);
        _curr = _history;
    }

    public void Visit(string url)
    {
        _curr.next = new DoublyLinkedListNode<string>(url, _curr);
        _curr = _curr.next;
    }

    public string Back(int steps)
    {
        while (steps > 0)
        {
            if (_curr.prev == null)
                break;
            _curr = _curr.prev;
            steps--;
        }
        return _curr.val;
    }

    public string Forward(int steps)
    {
        while (steps > 0) {
            if (_curr.next == null)
                break;
            _curr = _curr.next;
            steps--;
        }
        return _curr.val;
    }

    private class DoublyLinkedListNode<T>
    {
        public T val;
        public DoublyLinkedListNode<T> prev;
        public DoublyLinkedListNode<T> next;

        public DoublyLinkedListNode(T val = default(T), DoublyLinkedListNode<T> prev = null, DoublyLinkedListNode<T> next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }

        public T[] ToArray()
        {
            var currentNode = this;
            var nodeArray = new List<T>();
            while (currentNode != null)
            {
                nodeArray.Add(currentNode.val);
                currentNode = currentNode.next;
            }
            return nodeArray.ToArray();
        }

        public DoublyLinkedListNode<T> GetHead()
        {
            var node = this;
            while (node.prev != null)
            {
                node = node.prev;
            }
            return node;
        }
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */