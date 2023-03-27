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
        IList<int> res = new List<int>();
        if(root == null)
            return res;
        var stack = new Stack<TreeNode>();
        var currNode = root;
        while (currNode != null || stack.Count > 0) {
            while (currNode != null) { 
                stack.Push(currNode);
                currNode = currNode.left;
            }
            currNode = stack.Pop();
            res.Add(currNode.val);
            currNode = currNode.right;
        }
        return res;
    }
}