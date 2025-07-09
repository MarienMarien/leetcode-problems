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
    private int _maxSubTree;
    public int LargestBSTSubtree(TreeNode root) {
        _maxSubTree = root == null ? 0 : 1;
        _ = GetLargest(root);
        return _maxSubTree;
    }

    public (bool isBst, int nodesCount, int? maxVal, int? minVal) GetLargest(TreeNode node)
    {
        if(node == null)
        {
            return (true, 0, null, null);
        }

        var left = GetLargest(node.left);
        var right = GetLargest(node.right);
        var isBst = left.isBst && right.isBst;
        if((left.maxVal != null && node.val <= left.maxVal) || (right.minVal != null && right.minVal <= node.val))
            isBst = false;
        var nodesCount = left.nodesCount + right.nodesCount + 1;
        if(isBst)
            _maxSubTree = Math.Max(_maxSubTree, nodesCount);
        return (isBst, nodesCount, right.maxVal??node.val, left.minVal??node.val);
    }
}