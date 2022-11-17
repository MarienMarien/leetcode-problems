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
    public ListNode Partition(ListNode head, int x) {
        if (head == null || head.next == null)
            return head;
        var left = new ListNode();
        var ans = left;
        var right = new ListNode();
        var rightHead = right;
        while (head != null)
        {
            if (head.val < x)
            {
                left.next = head;
                left = left.next;
            }
            else
            {
                right.next = head;
                right = right.next;
            }
            head = head.next;
        }
        right.next = null;
        left.next = rightHead.next;
        return ans.next;
    }
}