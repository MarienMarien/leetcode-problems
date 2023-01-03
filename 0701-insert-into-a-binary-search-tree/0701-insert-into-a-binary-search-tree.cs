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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root == null)
            return new TreeNode(val);
        InsertNode(root, val);
        return root;
    }

    private static void InsertNode(TreeNode node, int val)
    {
        if (node == null)
            return;
        if (val < node.val)
        {
            if (node.left == null) {
                node.left = new TreeNode(val);
                return;
            }
            InsertNode(node.left, val);
        }
        else {
            if (node.right == null) { 
                node.right = new TreeNode(val);
                return;
            }
            InsertNode(node.right, val);
        }
    }
}