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
        ListNode newHead = new ListNode(0, head);
        ListNode reversedTail = null;
        ListNode leftPart = null;

        var curr = newHead;
        
        var id = 0;
        while (curr != null) {
            if (id == left - 1) {
                leftPart = curr;
                reversedTail = curr.next;
                curr = curr.next;
                id++;
                break;
            }
            id++;
            curr = curr.next;
        }

        if (reversedTail == null)
            return newHead.next;

        ListNode reversedHead = null;
        while (curr != null) {
            var tmp = curr.next;
            curr.next = reversedHead;
            reversedHead = curr;
            curr = tmp;

            if (id == right) {
                leftPart.next = reversedHead;
                reversedTail.next = curr;
                break;
            }

            id++;
        }

        return newHead.next;
    }
}