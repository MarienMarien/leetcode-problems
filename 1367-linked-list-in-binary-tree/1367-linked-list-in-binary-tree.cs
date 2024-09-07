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
    private ListNode _head;
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        _head = head;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            if (curr.val == head.val)
            {
                if (IsSubpath(curr, head))
                    return true;
            }
            if(curr.left != null)
                q.Enqueue(curr.left);
            if(curr.right != null)
                q.Enqueue(curr.right);
        }
        return false;
    }

    private bool IsSubpath(TreeNode node, ListNode listNode)
    {
        if (node == null)
            return listNode == null;
        if (listNode == null)
            return true;
        if(listNode.val != node.val)
            return false;

        return IsSubpath(node.left, listNode.next) || IsSubpath(node.right, listNode.next);
    }
}