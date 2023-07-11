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
    private IDictionary<TreeNode, TreeNode> _parents;
    private IList<int> _res;
    private ISet<TreeNode> _visited;
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        _parents = new Dictionary<TreeNode, TreeNode>();
        _visited = new HashSet<TreeNode>();
        _res = new List<int>();
        GetParents(root, null);
        GetDistanceK(target, k);
        return _res;
    }

    private void GetDistanceK(TreeNode curr, int k)
    {
        if (curr == null || _visited.Contains(curr))
            return;
        _visited.Add(curr);
        if (k == 0) {
            _res.Add(curr.val);
            return;
        }
        GetDistanceK(curr.left, k - 1);
        GetDistanceK(curr.right, k - 1);
        GetDistanceK(_parents[curr], k - 1);
    }

    private void GetParents(TreeNode curr, TreeNode parent)
    {
        if (curr == null)
            return;
        _parents.Add(curr, parent);
        GetParents(curr.left, curr);
        GetParents(curr.right, curr);
    }
}