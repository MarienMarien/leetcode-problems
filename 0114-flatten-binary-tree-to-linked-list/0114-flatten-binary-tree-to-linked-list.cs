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
    public void Flatten(TreeNode root) {
        var head = root;
        if (head == null)
            return;
        while (head != null)
        {
            // inserd left between root and right:
            // on root get left rightmost, point root -> left, rightmost -> on root.right
            if (head.left != null)
            {
                // get left rightmost
                var node = head.left;
                while (node.right != null)
                {
                    node = node.right;
                }
                node.right = head.right;
                head.right = head.left;
                head.left = null;// check if not changed;
            }
            head = head.right;
        }
    }
}