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
    public ListNode ReverseKGroup(ListNode head, int k) {
        return ReverseInGroup(head, k);
    }

    private ListNode ReverseInGroup(ListNode root, int k)
    {
        if (root == null || k == 0)
            return root;
        var head = new ListNode(0, root);
        var curr = root;
        var stack = new Stack<ListNode>();
        var count = k;
        while (count > 0 && curr != null) {
            stack.Push(curr);
            curr = curr.next;
            count--;
        }
        if (stack.Count == k)
        {
            var newHead = stack.Pop();
            head.next = newHead;
            while (stack.Count > 0) {
                newHead.next = stack.Pop();
                newHead = newHead.next;
            }
            newHead.next = ReverseInGroup(curr, k);
        }
        return head.next;
    }
}