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
        IList<int> result = new List<int>();
        if(root == null)
            return result;
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count > 0){
            var node = stack.Pop();
            if(node.right != null){
                stack.Push(node.right);
            }
            if(node.left != null){
                stack.Push(node.left);
            }
            result.Add(node.val);
        }
        return result;
    }
}