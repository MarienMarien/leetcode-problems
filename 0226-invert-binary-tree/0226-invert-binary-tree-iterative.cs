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
    public TreeNode InvertTree(TreeNode root) {
        if(root == null)
            return root;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var currNode = q.Dequeue();
            var tmp = currNode.right;
            currNode.right = currNode.left;
            currNode.left = tmp;
            if (currNode.left != null)
                q.Enqueue(currNode.left);
            if(currNode.right != null)
                q.Enqueue(currNode.right);
        }
        return root;
    }
}