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
    public TreeNode ReverseOddLevels(TreeNode root) {
        if (root == null || root.left == null)
            return root;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var level = 0;
        while (q.Count > 0)
        {
            var levelSize = q.Count;
            var levelNodes = new List<TreeNode>();
            for (var i = 0; i < levelSize; i++)
            {
                var currNode = q.Dequeue();
                levelNodes.Add(currNode);
                if (currNode.left == null)
                    continue;
                q.Enqueue(currNode.left);
                q.Enqueue(currNode.right);
            }
            if (level % 2 == 1)
            {
                var left = 0;
                var right = levelNodes.Count - 1;
                while (left < right)
                {
                    var tmp = levelNodes[left].val;
                    levelNodes[left].val = levelNodes[right].val;
                    levelNodes[right].val = tmp;
                    left++;
                    right--;
                }
            }
            level++;
        }

        return root;
    }
}