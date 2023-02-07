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
    private IList<TreeNode> _forest;
    private ISet<int> _toDelete;
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        _forest= new List<TreeNode>();
        _toDelete = new HashSet<int>(to_delete);
        if(to_delete.Length > 0)
            Traverse(root);
        if (!_toDelete.Contains(root.val))
            _forest.Add(root);
        return _forest;
    }
    private void Traverse(TreeNode node)
    {
        if (node == null)
            return;
        Traverse(node.left);
        if (node.left != null && _toDelete.Contains(node.left.val)) {
            node.left = null;
        }
        Traverse(node.right);
        if (node.right != null && _toDelete.Contains(node.right.val))
        {
            node.right = null;
        }
        if (_toDelete.Contains(node.val)) {
            if(node.left != null)
                _forest.Add(node.left);
            if (node.right != null)
                _forest.Add(node.right);
        }
    }
}