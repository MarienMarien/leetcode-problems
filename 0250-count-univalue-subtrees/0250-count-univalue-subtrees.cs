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
    private int _uniCount;
    public int CountUnivalSubtrees(TreeNode root)
    {
        _uniCount = 0;
        Count(root);
        return _uniCount;
    }

    private int Count(TreeNode root)
    {
        if (root == null)
            return 0;
        var countLeft = Count(root.left);
        var countRight = Count(root.right);
        var currUniCount = 0;
        if ((root.left == null && root.right == null)
            || (((countLeft > 0 && root.val == root.left.val) || root.left == null)
                && ((countRight > 0 && root.val == root.right.val) || root.right == null))) 
        {
            _uniCount++;
            currUniCount = _uniCount;
        }
        return currUniCount;
    }
}