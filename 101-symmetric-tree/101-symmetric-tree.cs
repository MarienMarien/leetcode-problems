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
    public bool IsSymmetric(TreeNode root) {
        if (root == null || (root.left == null && root.right == null))
        {
            return true;
        }
        if (root.left == null || root.right == null) {
            return false;
        }
        var lTreeQ = new Queue<TreeNode>();
        lTreeQ.Enqueue(root.left);

        var rTreeQ = new Queue<TreeNode>();
        rTreeQ.Enqueue(root.right);
        while (lTreeQ.Count > 0) {
            var rtVal = rTreeQ.Dequeue();
            if (lTreeQ.Count == 0)
                return false;
            var ltVal = lTreeQ.Dequeue();
            if (rtVal.val != ltVal.val)
                return false;
            if (ltVal.left?.val != rtVal.right?.val)
            {
                return false;
            }
            if (ltVal.right?.val != rtVal.left?.val) {
                return false;
            }
            if (ltVal.left != null)
                lTreeQ.Enqueue(ltVal.left);
            if (ltVal.right != null)
                lTreeQ.Enqueue(ltVal.right);

            if (rtVal.right != null)
                rTreeQ.Enqueue(rtVal.right);
            if (rtVal.left != null)
                rTreeQ.Enqueue(rtVal.left);
        }
        if (lTreeQ.Count > 0)
            return false;

        return true;
    }
}