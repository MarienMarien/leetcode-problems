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
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        if (head == null)
            return null;
        return BuildTree(head, null);
    }

    private TreeNode BuildTree(ListNode head, ListNode end) {
        if (head == end) {
            return head == null ? null : new TreeNode(head.val);
        }
        ListNode midPrev = null;
        var mid = head;
        var fast = head;
        while (fast != end && fast.next != end)
        {
            midPrev = mid;
            mid = mid.next;
            fast = fast.next.next;
        }
        if (midPrev == null)
        {
            return new TreeNode(head.val, null, end == null ? null : new TreeNode(end.val));
        }
        else
        {
            return new TreeNode(mid.val, BuildTree(head, midPrev), BuildTree(mid.next, end));
        }
    }
}