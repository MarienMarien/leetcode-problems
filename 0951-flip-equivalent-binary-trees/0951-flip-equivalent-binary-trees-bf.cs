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
    private IDictionary<int, ISet<int>> _nodesMap;
    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 == root2)
            return true;
        if (root1 == null || root2 == null)
            return false;

        _nodesMap = new Dictionary<int, ISet<int>>();
        BuildNodesMap(root1);
        return IsFlipped(root2);
    }

    private bool IsFlipped(TreeNode node)
    {
        if (node == null)
            return true;
        if (!_nodesMap.ContainsKey(node.val))
            return false;

        var childrenCount = (node.left != null ? 1 : 0) + (node.right != null ? 1 : 0);
        if (childrenCount != _nodesMap[node.val].Count)
            return false;
        if (node.left != null && !_nodesMap[node.val].Contains(node.left.val))
            return false;
        if (node.right != null && !_nodesMap[node.val].Contains(node.right.val))
            return false;

        return IsFlipped(node.left) && IsFlipped(node.right);
    }

    private void BuildNodesMap(TreeNode node)
    {
        if (node == null)
            return;
        _nodesMap.Add(node.val, new HashSet<int>());
        if (node.left != null)
        {
            _nodesMap[node.val].Add(node.left.val);
            BuildNodesMap(node.left);
        }

        if (node.right != null)
        {
            _nodesMap[node.val].Add(node.right.val);
            BuildNodesMap(node.right);
        }
    }
}