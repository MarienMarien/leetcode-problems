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
    public TreeNode InvertTree(TreeNode root) {
        Invert(root);
        return root;
    }

    private void Invert(TreeNode root)
    {
        if (root == null)
            return;
        Invert(root.left);
        Invert(root.right);
        if(root.left != null || root.right != null){
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
        }
    }
}