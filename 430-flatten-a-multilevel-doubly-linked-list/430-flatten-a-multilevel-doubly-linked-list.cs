/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) {
         var prevRowsNext = new Stack<Node>();
            var startList = head;
            while (head != null) {
                if (head.child != null) {
                  if(head.next != null)
                    prevRowsNext.Push(head.next);
                    head.child.prev = head;
                    head.next = head.child;
                    head.child = null;
                }
                if (head.next == null) {
                    if (prevRowsNext.TryPop(out Node returnToNode))
                    {
                        if (returnToNode != null)
                        {
                            head.next = returnToNode;
                            returnToNode.prev = head;
                        }
                    }
                }
                head = head.next;
            }
            return startList;
    }
}