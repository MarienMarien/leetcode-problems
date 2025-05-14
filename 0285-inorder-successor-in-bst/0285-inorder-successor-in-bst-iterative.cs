/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode successor = null;
        var node = root;
        while(node != null)
        {
            if(node.val <= p.val)
            {
                node = node.right;
            }
            else
            {
                successor = node;
                node = node.left;
            }
        }
        return successor;
    }
}