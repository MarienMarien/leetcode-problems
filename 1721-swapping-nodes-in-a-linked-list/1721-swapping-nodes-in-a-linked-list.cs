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
    public ListNode SwapNodes(ListNode head, int k) {
        ListNode newHead = new ListNode(0, head);
        ListNode curr = head;

        ListNode kHead = head;
        ListNode kTail = head;
        
        while (curr.next != null)
        {
            k--;
            if (k > 0) {
                kHead = kHead.next;
                
            }
            if (k <= 0) {
                kTail = kTail.next;
            }
            curr = curr.next;
        }
        var tmp = kTail.val;
        kTail.val = kHead.val;
        kHead.val = tmp;

        return newHead.next;
    }
}