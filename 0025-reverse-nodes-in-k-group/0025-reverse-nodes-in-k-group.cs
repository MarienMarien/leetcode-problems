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
    public ListNode ReverseKGroup(ListNode head, int k) {
        var nodesCount = 0;
        var curr = head;
        while (curr != null) { 
            nodesCount++;
            curr = curr.next;
        }
        return ReverseInGroupO1Space(head, k, nodesCount);
    }

    private ListNode ReverseInGroupO1Space(ListNode root, int k, int nodesLeft)
    {
        if (root == null || k == 0 || nodesLeft < k)
            return root;
        var count = k;
        var curr = root;
        ListNode head = null;
        ListNode next;
        while (count > 0) {
            next = curr.next;
            curr.next = head;
            head = curr;
            curr = next;
            count--;
        }
        root.next = ReverseInGroupO1Space(curr, k, nodesLeft - k);
        return head;
    }
}