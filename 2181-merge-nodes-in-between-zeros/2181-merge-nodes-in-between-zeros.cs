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
    public ListNode MergeNodes(ListNode head) {
        var currZero = head;
        var curr = head.next;
        while (curr != null)
        {
            var sum = 0;
            while (curr.val != 0) {
                sum += curr.val;
                curr = curr.next;
            }
            currZero.val = sum;
            if (curr.next != null)
                currZero.next = curr;
            else
                currZero.next = null;
            currZero = currZero.next;
            curr = curr.next;
        }

        return head;
    }
}