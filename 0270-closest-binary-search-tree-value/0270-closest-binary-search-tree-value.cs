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
    public int ClosestValue(TreeNode root, double target) {
         return DFS(root, target, root.val, Math.Abs(root.val - target));
    }

    private int DFS(TreeNode root, double target, int nodeVal, double diff)
    {
        if (root == null)
            return nodeVal;
        var curr = Math.Abs(target - root.val);
        if (curr < diff)
        {
            diff = curr;
            nodeVal = root.val;
        }
        if(diff > 0 && root.val > target)
            nodeVal = DFS(root.left, target, nodeVal, diff);
        else
            nodeVal = DFS(root.right, target, nodeVal, diff);
        return nodeVal;
    }
}