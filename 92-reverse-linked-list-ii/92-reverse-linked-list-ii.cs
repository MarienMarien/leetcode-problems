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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (left > right)
                return null;
            ListNode firstNode = head;
            ListNode from = left > 1 ? head : null;
            ListNode to = null;
            ListNode newListStart = null;
            ListNode newListEnd = null;
            var i = 1;
            while (head != null) {
                if (i == left) {
                    newListStart = new ListNode(head.val);
                    newListEnd = newListStart;
                }
                if (left < i && i <= right) {
                    newListEnd = new ListNode(head.val, newListEnd);
                }
                if (i > right) {
                    to = head;
                    break;
                }
                if (i == left-1) {
                    from = head;
                }
                head = head.next;
                i++;
            }
            if (from != null)
            {
                from.next = newListEnd;
            }
            else {
                firstNode = newListEnd;
            }
            if (to != null && newListStart != null) {
                newListStart.next = to;
            }
            return firstNode;
    }
}