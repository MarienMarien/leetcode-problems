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
    private IList<int> _nodes;
    public int MinDiffInBST(TreeNode root)
    {
        _nodes = new List<int>();
        TraverseBfs(root);
        var minDiff = Int32.MaxValue;
        for (var i = 1; i < _nodes.Count; i++) {
            minDiff = Math.Min(minDiff, _nodes[i] - _nodes[i-1]);
        }
        return minDiff;
    }

    private void TraverseBfs(TreeNode root)
    {
        if (root == null)
            return;
        TraverseBfs(root.left);
        _nodes.Add(root.val);
        TraverseBfs(root.right);
    }
}