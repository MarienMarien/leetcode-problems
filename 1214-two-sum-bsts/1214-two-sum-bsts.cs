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
    public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target) {
        var complementarySet = new HashSet<int>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root1);
        while (q.Count > 0) {
            var curr = q.Dequeue();
            complementarySet.Add(target - curr.val);
            if (curr.left != null)
                q.Enqueue(curr.left);
            if(curr.right != null)
                q.Enqueue(curr.right);
        }
        q = new Queue<TreeNode>();
        q.Enqueue(root2);
        while (q.Count > 0) { 
            var curr = q.Dequeue();
            if (complementarySet.Contains(curr.val))
                return true;
            if (curr.left != null)
                q.Enqueue(curr.left);
            if (curr.right != null)
                q.Enqueue(curr.right);
        }
        return false;
    }
}