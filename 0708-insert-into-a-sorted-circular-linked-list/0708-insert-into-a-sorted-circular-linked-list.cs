/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next) {
        val = _val;
        next = _next;
    }
}
*/

public class Solution {
    public Node Insert(Node head, int insertVal) {
        var newNode = new Node(insertVal);
        if (head == null) {
            newNode.next = newNode;
            return newNode;
        }
        var headNode = head;
        do
        {
            if ((headNode.val > insertVal && headNode.next.val > insertVal && headNode.val > headNode.next.val)
                ||(headNode.val <= insertVal && headNode.next.val >= insertVal)
                || (headNode.val < insertVal && headNode.val > headNode.next.val)) { 
                break;
            }
            headNode = headNode.next;
        } while (head != headNode);
        newNode.next = headNode.next;
        headNode.next = newNode;
        return head;
    }
}