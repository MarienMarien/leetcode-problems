/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    private int _n;
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        _n = n;
        return GetNewList(head);
    }

    private ListNode GetNewList(ListNode node)
    {
        if(node == null)
            return null;
        node.next = GetNewList(node.next);
        _n--;
        if(_n == 0)
            return node.next;
        return node;
    }
}