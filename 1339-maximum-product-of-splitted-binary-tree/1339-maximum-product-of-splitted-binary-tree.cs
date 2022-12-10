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
    private IList<long> _sums = new List<long>();
    public int MaxProduct(TreeNode root)
    {
        var totalSum = CountSum(root);
        long maxProduct = 0;
        foreach (var el in _sums) {
            maxProduct = Math.Max(maxProduct, el *(totalSum - el));
        }
        return (int)(maxProduct % 1000000007);
    }

    private long CountSum(TreeNode node) {
        if (node == null)
            return 0;
        var leftSum = CountSum(node.left);
        var rightSum = CountSum(node.right);
        var sum = leftSum + rightSum + node.val;
        _sums.Add(sum);
        return sum;
    }
}