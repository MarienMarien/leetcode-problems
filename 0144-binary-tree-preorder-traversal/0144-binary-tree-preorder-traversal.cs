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
    public IList<int> PreorderTraversal(TreeNode root) {
        return Traverse(root, new List<int>());
    }

    private IList<int> Traverse(TreeNode root, IList<int> list)
    {
        if (root == null)
            return list;
        list.Add(root.val);
        list = Traverse(root.left, list);
        list = Traverse(root.right, list);
        return list;
    }
}