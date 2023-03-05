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
    public long KthLargestLevelSum(TreeNode root, int k) {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var pq = new PriorityQueue<long, long>(Comparer<long>.Create((x, y) => y.CompareTo(x)));
        var levelSize = 1;
        var nextLevelSize = 0;
        long levelSum = 0;
        while (q.Count > 0) {
            var curr = q.Dequeue();
            levelSize--;
            levelSum += curr.val;
            if (curr.left != null) {
                q.Enqueue(curr.left);
                nextLevelSize++;
            }
            if (curr.right != null)
            {
                q.Enqueue(curr.right);
                nextLevelSize++;
            }
            if (levelSize == 0) {
                levelSize = nextLevelSize;
                nextLevelSize = 0;
                pq.Enqueue(levelSum, levelSum);
                levelSum = 0;
            }
        }
        while (pq.Count > 0) {
            k--;
            var curr = pq.Dequeue();
            if (k == 0)
                return curr;
        }
        return -1;
    }
}