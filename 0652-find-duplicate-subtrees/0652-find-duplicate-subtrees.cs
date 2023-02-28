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
    private ISet<string> _subtrees;
    private IDictionary<string, TreeNode> _result;
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        _subtrees = new HashSet<string>();
        _result = new Dictionary<string,TreeNode>();
        var rootTree = GetTreeStr(root);
        return _result.Values.ToList();
    }

    private string GetTreeStr(TreeNode node)
    {
        if (node == null)
            return "";
        var sb = new StringBuilder();
        sb.Append(node.val);
        var left = GetTreeStr(node.left);
        sb.Append(',').Append(left.Length > 0 ? left : "null");
        var right = GetTreeStr(node.right);
        sb.Append(',').Append(right.Length > 0 ? right : "null");
        var subtreeStr = sb.ToString();
        if (_subtrees.Contains(subtreeStr) && !_result.ContainsKey(subtreeStr))
        {
            _result.Add(subtreeStr, node);
        }
        else {
            _subtrees.Add(subtreeStr);
        }
        return subtreeStr;
    }
}