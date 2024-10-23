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
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        var level = new Queue<TreeNode>();
        level.Enqueue(root);
        var nextLevelSum = 0;
        var levelSize = 1;
        var levelSums = new Dictionary<int, int>();
        var nextLevelNo = 1;

        while (level.Count > 0)
        {
            var curr = level.Dequeue();
            levelSize--;

            if (curr.left != null)
            {
                level.Enqueue(curr.left);
                nextLevelSum += curr.left.val;
            }

            if (curr.right != null)
            {
                level.Enqueue(curr.right);
                nextLevelSum += curr.right.val;
            }

            if (levelSize == 0)
            {
                levelSums.Add(nextLevelNo, nextLevelSum);
                nextLevelNo++;
                nextLevelSum = 0;
                levelSize = level.Count;
            }
            
        }

        var q = new Queue<TreeNode>();
        root.val = 0;
        q.Enqueue(root);
        nextLevelNo = 1;
        levelSize = 1;

        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            levelSize--;
            var childValsSum = (curr.left == null ? 0 : curr.left.val) 
                + (curr.right == null ? 0 : curr.right.val);
            if (curr.left != null)
            {
                curr.left.val = levelSums[nextLevelNo] - childValsSum;
                q.Enqueue(curr.left);
            }

            if (curr.right != null)
            {
                curr.right.val = levelSums[nextLevelNo] - childValsSum;
                q.Enqueue(curr.right);
            }


            if (levelSize == 0)
            {
                levelSize = q.Count;
                nextLevelNo++;
            }
        }

        return root;
    }
}