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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null)
            return true;
        var pQue = new Queue<TreeNode>();
        pQue.Enqueue(p);
        var qQue = new Queue<TreeNode>();
        qQue.Enqueue(q);
        while (pQue.Count > 0) {
            var pVal = pQue.Dequeue();
            var qVal = qQue.Dequeue();
            if (pVal?.val != qVal?.val)
                return false;
            if (pVal?.left?.val != qVal.left?.val)
                return false;
            if (pVal.right?.val != qVal.right?.val)
                return false;
            if(pVal.left != null)
                pQue.Enqueue(pVal.left);
            if(pVal.right != null)
                pQue.Enqueue(pVal.right);
            if (qVal.left != null)
                qQue.Enqueue(qVal.left);
            if (qVal.right != null)
                qQue.Enqueue(qVal.right);
        }
        if (qQue.Count > 0)
            return false;
        return true;
    }
}