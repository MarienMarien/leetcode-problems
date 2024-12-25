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
        var resVals = new List<int>();
        if(root == null)
            return resVals;
        resVals.Add(root.val);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var levelSize = 1;
        var levelMax = Int32.MinValue;
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            levelSize--;

            if(curr.left != null)
            {
                q.Enqueue(curr.left);
                levelMax = Math.Max(levelMax, curr.left.val);
            }

            if(curr.right != null)
            {
                q.Enqueue(curr.right);
                levelMax = Math.Max(levelMax, curr.right.val);
            }

            if(levelSize == 0)
            {
                levelSize = q.Count;
                if(levelSize > 0)
                    resVals.Add(levelMax);
                levelMax = Int32.MinValue;
            }
        }

        return resVals;
    }
}