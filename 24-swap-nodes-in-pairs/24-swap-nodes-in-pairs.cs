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
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null)
                return head;
            ListNode res = new ListNode(-1);
            res.next = head;
            var prevNode = res;
            while (head != null && head.next != null) {
                // assign nodes to swap
                var node1 = head;
                var node2 = head.next;
                // swapNodes
                prevNode.next = node2;
                node1.next = node2.next;
                node2.next = node1;
                // jump
                head = node1.next;
                prevNode = node1;
            }
            return res.next;
    }
}