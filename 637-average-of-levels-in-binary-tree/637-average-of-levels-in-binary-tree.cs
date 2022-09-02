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
    public IList<double> AverageOfLevels(TreeNode root) {
        IList<double> res = new List<double>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var levelNodesCnt = 1.0;
        var currSum = 0.0;
        var divisor = levelNodesCnt;
        while (q.Count > 0) {
            var curr = q.Dequeue();
            levelNodesCnt--;
            currSum += curr.val;
            if (curr.left != null)
                q.Enqueue(curr.left);
            if (curr.right != null)
                q.Enqueue(curr.right);

            if (levelNodesCnt == 0) {
                res.Add(currSum / divisor);
                levelNodesCnt = q.Count;
                divisor = levelNodesCnt;
                currSum = 0;
            }
        }
        return res;
    }
}