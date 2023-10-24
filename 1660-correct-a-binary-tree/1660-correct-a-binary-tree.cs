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
    private ISet<TreeNode> _visited;
    public TreeNode CorrectBinaryTree(TreeNode root)
    {
        _visited = new HashSet<TreeNode>();
        return CorrectBinTree(root);
    }

    private TreeNode CorrectBinTree(TreeNode node)
    {
        if (node == null)
            return null;

        if (node.right != null && _visited.Contains(node.right)) {
            return null;
        }
        _visited.Add(node);

        node.right = CorrectBinTree(node.right);
        node.left = CorrectBinTree(node.left);

        return node;
    }
}