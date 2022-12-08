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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        var tree1Leaves = new List<int>();
        var tree2Leaves = new List<int>();
        tree1Leaves = GetLeaves(root1, tree1Leaves);
        tree2Leaves = GetLeaves(root2, tree2Leaves);
        if (tree1Leaves.Count != tree2Leaves.Count)
            return false;
        for (var i = 0; i < tree1Leaves.Count; i++) {
            if (tree1Leaves[i] != tree2Leaves[i])
                return false;
        }
        return true;
    }

    private List<int> GetLeaves(TreeNode root, List<int> leaves)
    {
        if(root == null)
            return leaves;
        if (root.left == null && root.right == null) {
            leaves.Add(root.val);
            return leaves;
        }
        leaves = GetLeaves(root.left, leaves);
        return GetLeaves(root.right, leaves);
    }
}