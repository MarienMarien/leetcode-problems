/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        var map = new Dictionary<Node, Node>();
        var result = new Node(0);
        var curr = head;
        var newCurr = result;
        while (curr != null) {
            var newNode = new Node(curr.val);
            map.Add(curr, newNode);
            newCurr.next = newNode;
            newCurr = newCurr.next;
            curr = curr.next;
        }
        curr = head;
        newCurr = result.next;
        while (curr != null) {
            if (curr.random != null)
            {
                var rand = map[curr.random];
                newCurr.random = rand;
            }
            curr = curr.next;
            newCurr = newCurr.next;
        }

        return result.next;
    }
}