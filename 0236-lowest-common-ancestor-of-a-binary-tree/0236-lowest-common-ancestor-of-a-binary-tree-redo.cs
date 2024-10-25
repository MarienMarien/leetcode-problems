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
    private ISet<TreeNode> _pAncestors;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        _pAncestors = new HashSet<TreeNode>();
        HasPAncestors(root, p);
        return FindLowestCommon(root, q).ancestor;
    }

    private (TreeNode ancestor, bool qFound) FindLowestCommon(TreeNode node, TreeNode q)
    {
        if (node == null)
            return (null, false);
        if (node == q)
        {
            return ((_pAncestors.Contains(node)? node : null), true);
        }
        var ancestor = FindLowestCommon(node.left, q);
        if(!ancestor.qFound)
            ancestor = FindLowestCommon(node.right, q);
        if (ancestor.qFound && ancestor.ancestor == null && _pAncestors.Contains(node))
            ancestor = (node, true);
            
        return ancestor;
    }

    private bool HasPAncestors(TreeNode node, TreeNode p)
    {
        if (node == null)
            return false;
        if (node == p) 
        {
            _pAncestors.Add(node);
            return true;
        }
        var pFound = HasPAncestors(node.left, p);
        if(!pFound)
            pFound = HasPAncestors(node.right, p);
        if (pFound)
            _pAncestors.Add(node);
        return pFound;
    }
}