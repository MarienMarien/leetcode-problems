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
        var stack = new Stack<ListNode>();
        // find second part of list
        var fast = head;
        var slow = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        var tmp = slow.next;
        slow.next = null;
        // fill stack
        while (tmp != null) {
            stack.Push(tmp);
            tmp = tmp.next;
        }

        // rearange
        var curr = head;
        while (curr != null)
        {
            ListNode node;
            var isStackNotEmpty = stack.TryPop(out node);
            if (isStackNotEmpty) {
                node.next = curr.next;
                curr.next = node;
                curr = curr.next;
            }
            curr = curr.next;
        }
    }
}