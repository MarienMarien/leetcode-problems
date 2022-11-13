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
    private Stack<TreeNode> _pPath;
    private Stack<TreeNode> _qPath;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (p == q)
            return p;
        _pPath = new Stack<TreeNode>();
        _qPath = new Stack<TreeNode>();
        FoundSecondPath(root, p, _pPath);
        FoundSecondPath(root, q, _qPath);
        var set = new HashSet<TreeNode>(_pPath);
        while (_qPath.Count > 0) {
            var curr = _qPath.Pop();
            if (set.Contains(curr)) {
                return curr;
            }
        }
        return root;
    }

    private bool FoundSecondPath(TreeNode root, TreeNode q, Stack<TreeNode> stack)
    {
        if (root == null)
            return false;
        stack.Push(root);
        if (root == q)
            return true;
        var found = FoundSecondPath(root.left, q, stack);
        if (!found) {
            
            found = FoundSecondPath(root.right, q, stack);
        }
        if(!found)
            stack.Pop();
        return found;
    }
}