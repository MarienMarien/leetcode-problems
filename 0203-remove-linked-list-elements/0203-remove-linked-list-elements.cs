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
    public ListNode RemoveElements(ListNode head, int val) {
        var newHead = new ListNode();
        var curr = newHead;
        while (head != null) {
            if (head.val == val)
                curr.next = null;
            else
            {
                curr.next = head;
                curr = curr.next;
            }
            head = head.next;
        }
        return newHead.next;
    }
}