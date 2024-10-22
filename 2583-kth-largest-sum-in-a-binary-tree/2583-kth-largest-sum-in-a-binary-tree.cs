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
        var levelSize = 1;
        var levelSum = 0L;
        var pq = new PriorityQueue<long, long>();
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            levelSum += curr.val;
            levelSize--;

            if(curr.left != null)
                q.Enqueue(curr.left);
            if(curr.right != null)
                q.Enqueue(curr.right);

            if(levelSize == 0)
            {
                pq.Enqueue(levelSum, levelSum);
                if(pq.Count > k)
                {
                    pq.Dequeue();
                }
                levelSize = q.Count;
                levelSum = 0;
            }
        }

        return pq.Count < k ? -1 : pq.Dequeue();
    }
}