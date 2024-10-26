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
    private IDictionary<int, int> _maxHeightAfterRem;
    private int _maxHeight;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        _maxHeightAfterRem = new Dictionary<int, int>();
        Func<TreeNode, TreeNode> getLeft = (node) => node.left;
        Func<TreeNode, TreeNode> getRight = (node) => node.right;

        TraverseTree(root, getLeft, getRight, 0);
        _maxHeight = 0;
        TraverseTree(root, getRight, getLeft, 0);

        var res = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            res[i] = _maxHeightAfterRem[queries[i]];
        }

        return res;
    }

    private void TraverseTree(TreeNode node, Func<TreeNode, TreeNode> getFirst, Func<TreeNode, TreeNode> getSecond, int currHeight)
    {
        if (node == null)
            return;
        if(!_maxHeightAfterRem.ContainsKey(node.val))
            _maxHeightAfterRem.Add(node.val, 0);
        _maxHeightAfterRem[node.val] = Math.Max(_maxHeightAfterRem[node.val], _maxHeight);
        _maxHeight = Math.Max(_maxHeight, currHeight);

        TraverseTree(getFirst(node), getFirst, getSecond, currHeight + 1);
        TraverseTree(getSecond(node), getFirst, getSecond, currHeight + 1);
    }
}