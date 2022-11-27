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
    private IList<IList<int>> _result;
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        _result = new List<IList<int>>();
        FindPathSum(root, targetSum, 0, new List<int>());
        return _result;
    }

    private void FindPathSum(TreeNode root, int targetSum, int currSum, List<int> list)
    {
        if (root == null)
            return;
        if (Math.Abs(targetSum - (currSum + root.val))  < 0 )
            return;

        currSum += root.val;
        list.Add(root.val);
        if (currSum == targetSum && root.left == null && root.right == null) {
            _result.Add(new List<int>(list));
        } else {
            FindPathSum(root.left, targetSum, currSum, list);
            FindPathSum(root.right, targetSum, currSum, list);
        }
        list.RemoveAt(list.Count - 1);
    }
}