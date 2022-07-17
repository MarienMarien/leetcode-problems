public class MinStack {

     private Node _Head;

        public void Push(int val)
        {
            if (_Head == null)
                _Head = new Node(val, val, null);
            else {
                 _Head = new Node(val, Math.Min(val, _Head.Min), _Head);
            }
        }

        public void Pop()
        {
            _Head = _Head.Next;
        }

        public int Top()
        {
            return _Head.Value;
        }

        public int GetMin()
        {
            return _Head.Min;
        }

    }

    public class Node {
        public Node(int val, int min, Node next)
        {
            Min = min;
            Value = val;
            Next = next;
        }
        public int Value { get; set; }
        public int Min { get; set; }
        public Node Next { get; set; }
    }

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */