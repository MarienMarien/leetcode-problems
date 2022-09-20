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
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null)
            return;
        // find second part of list
        var fast = head;
        var slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        // reverse 2nd part
        ListNode rev = null;
        var curr = slow;
        while (curr != null) {
            var tmp = curr.next;
            curr.next = rev;
            rev = curr;
            curr = tmp;
        }

        // merge
        var root = head;
        while (rev.next != null) {
            var tmp = root.next;
            root.next = rev;
            root = tmp;

            tmp = rev.next;
            rev.next = root;
            rev = tmp;
        }
    }
}