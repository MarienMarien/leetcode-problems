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
    public bool IsCompleteTree(TreeNode root) {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var nullNodeFound = false;
        while (q.Count > 0) {
            var curr = q.Dequeue();
            if (curr == null)
            {
                nullNodeFound = true;
            }
            else {
                if (nullNodeFound)
                    return false;
                q.Enqueue(curr.left);
                q.Enqueue(curr.right);
            }
        }
        return true;
    }
}