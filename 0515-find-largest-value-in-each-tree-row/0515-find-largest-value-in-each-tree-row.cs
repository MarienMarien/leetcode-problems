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
    public IList<int> LargestValues(TreeNode root) {
        var ans = new List<int>();
        if (root == null)
            return ans;
        
        var currMax = Int32.MinValue;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var rowLen = 1;

        while (q.Count > 0) { 
            var node = q.Dequeue();
            rowLen--;
            currMax = Math.Max(currMax, node.val);
            if (node.left != null)
                q.Enqueue(node.left);
            if(node.right != null)
                q.Enqueue(node.right);
            if (rowLen == 0) {
                ans.Add(currMax);
                currMax = Int32.MinValue;
                rowLen = q.Count;
            }
        }

        return ans;
    }
}