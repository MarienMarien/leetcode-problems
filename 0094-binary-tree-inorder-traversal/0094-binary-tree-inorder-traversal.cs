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
    public IList<int> InorderTraversal(TreeNode root) {
       return Traverse(root, new List<int>());
    }

    private static IList<int> Traverse(TreeNode root, IList<int> res)
    {
        if (root == null)
            return res;
        res = Traverse(root.left, res);
        res.Add(root.val);
        return Traverse(root.right, res);
    }
}