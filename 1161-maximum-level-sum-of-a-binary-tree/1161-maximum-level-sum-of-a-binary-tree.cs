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
    public int MaxLevelSum(TreeNode root) {
        var maxSum = Int32.MinValue;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var currSum = 0;
        var layerSize = 1;
        var nextLayerSize = 0;
        var layerNo = 1;
        var res = layerNo;
        while (q.Count > 0) {
            var node = q.Dequeue();
            layerSize--;
            currSum += node.val;
            if (node.left != null) { 
                q.Enqueue(node.left);
                nextLayerSize++;
            }
            if (node.right != null)
            {
                q.Enqueue(node.right);
                nextLayerSize++;
            }
            if (layerSize == 0) {
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    res = layerNo;
                }
                layerNo++;
                layerSize = nextLayerSize;
                currSum = 0;
                nextLayerSize = 0;
            }
        }
        return res;
    }
}