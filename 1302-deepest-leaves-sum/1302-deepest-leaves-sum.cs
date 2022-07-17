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
    public int DeepestLeavesSum(TreeNode root) {
        var sum = 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var nextLayer = new Queue<TreeNode>(0);
            while (q.Count > 0) {
                var currentNode = q.Dequeue();
                sum += currentNode.val;
                if(currentNode.left != null)
                    nextLayer.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    nextLayer.Enqueue(currentNode.right);
                if (q.Count == 0) {
                    if (nextLayer.Count > 0) {
                        sum = 0;
                        q = nextLayer;
                        nextLayer = new Queue<TreeNode>();
                    }
                }
            }
            return sum;
    }
}