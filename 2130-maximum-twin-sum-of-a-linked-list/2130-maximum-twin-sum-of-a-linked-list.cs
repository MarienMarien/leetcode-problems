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
    public int PairSum(ListNode head) {
        if (head.next != null && head.next.next == null)
            return head.val + head.next.val;
        ListNode fast = head.next.next;
        ListNode slow = head;
        Stack<int> stack = new Stack<int>();
        stack.Push(slow.val);
        while (fast != null) {
            slow = slow.next;
            fast = fast.next.next;
            stack.Push(slow.val);
        }
        int result = 0;
        slow = slow.next;
        while (slow != null) {
            result = Math.Max(result, slow.val + stack.Pop());
            slow = slow.next;
        }
        return result;
    }
}