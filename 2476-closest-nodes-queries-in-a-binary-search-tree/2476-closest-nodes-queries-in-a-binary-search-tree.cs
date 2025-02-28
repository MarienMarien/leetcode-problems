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
    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries) {
        var sortedValues = new List<int>();
        GetSortedValues(root, sortedValues);

        var result = new List<IList<int>>();
        
        foreach(var q in queries)
        {
            var lower = 0;
            var upper = sortedValues.Count - 1;
            while (lower <= upper)
            {
                var mid = (lower + upper) / 2;
                if (sortedValues[mid] == q)
                {
                    lower = mid;
                    upper = mid;
                    break;
                }
                if (sortedValues[mid] > q)
                {
                    upper = mid - 1;
                }
                else
                {
                    lower = mid + 1;
                }
            }

            lower = lower == sortedValues.Count ? -1 : sortedValues[lower];
            upper = upper < 0 ? -1 : sortedValues[upper];
            result.Add(new List<int> { upper, lower });
        }

        return result;
    }

    private void GetSortedValues(TreeNode node, IList<int> sorted)
    {
        if(node == null)
            return;
        GetSortedValues(node.left, sorted);
        sorted.Add(node.val);
        GetSortedValues(node.right, sorted);
    }
}