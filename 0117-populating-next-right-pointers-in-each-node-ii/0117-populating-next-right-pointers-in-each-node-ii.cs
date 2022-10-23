/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null)
            return root;
        var head = root;
        var q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Count != 0) { 
            var curr = q.Dequeue();
            if (curr.left != null) {
                curr.left.next = GetNext(curr, true);
                q.Enqueue(curr.left);
            }
            if (curr.right != null) {
                curr.right.next = GetNext(curr, false);
                q.Enqueue(curr.right);
            }
        }

        return head;
    }

    private Node GetNext(Node curr, bool isLeft)
    {
        if (isLeft && curr.right != null)
            return curr.right;
        while (curr.next != null) {
            if (curr.next.left != null)
                return curr.next.left;
            if (curr.next.right != null)
                return curr.next.right;
            curr = curr.next;
        }
        return null;
    }
}