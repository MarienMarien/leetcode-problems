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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode deletePoint = null;
        ListNode curr = head;
        var cnt = 0 - (n - 1);
        while (curr.next != null)
        {
            if (cnt == 0) deletePoint = head;
            if (cnt > 0)
            {
                deletePoint = deletePoint.next;
            }
            curr = curr.next;
            cnt++;
        }
        if (deletePoint == null)
            return head.next;
        deletePoint.next = deletePoint.next.next;
        return head;
    }
}