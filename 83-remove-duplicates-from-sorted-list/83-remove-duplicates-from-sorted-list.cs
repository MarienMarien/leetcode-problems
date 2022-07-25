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
        var root = head;
        var prevItem = head;
        head = head.next;
        while (head != null) {
            if (head.val == prevItem.val) {
                prevItem.next = head.next;
                head = head.next;
                continue;
            }
            prevItem = head;
            head = head.next;
        }
        return root;
    }
}