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
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null)
            return head;
        var prev = new ListNode(0, head);
        var ans = prev;
        var curr = head;
        while (curr != null) {
            if (curr.val == curr.next?.val) {
                var val = curr.val;
                while (curr != null && curr.val == val)
                    curr = curr.next;
                prev.next = curr;
            } else { 
                prev.next = curr;
                prev = prev.next;
                curr = curr.next;
            }
        }
        return ans.next;
    }
}