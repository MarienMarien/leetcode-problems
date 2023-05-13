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
    public TreeNode FindNearestRightNode(TreeNode root, TreeNode u) {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int levelSize = 1;
        TreeNode rightNeighbor= null;
        while (q.Count > 0) {
            TreeNode currNode = q.Dequeue();
            levelSize--;
            if (currNode == u) {
                if (levelSize > 0)
                    rightNeighbor = q.Peek();
                break;
            }
            if (currNode.left != null)
                q.Enqueue(currNode.left);
            if (currNode.right != null)
                q.Enqueue(currNode.right);
            if (levelSize == 0)
                levelSize = q.Count;
        }
        return rightNeighbor;
    }
}