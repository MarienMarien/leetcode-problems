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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        IList<IList<int>> ans = new List<IList<int>>();
        if (root == null)
                return ans;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var levelLen = 1;
        var levelList = new List<int>();
        while (q.Count > 0) {
            var curr = q.Dequeue();
            levelLen--;
            levelList.Add(curr.val);
            if (curr.left != null)
                q.Enqueue(curr.left);
            if (curr.right != null)
                q.Enqueue(curr.right);
            if (levelLen == 0) {
                levelLen = q.Count;
                ans.Add(new List<int>(levelList));
                levelList = new List<int>();
            }
        }
        var start = 0;
        var end = ans.Count - 1;
        while (start < end) {
            var tmp = ans[start];
            ans[start] = ans[end];
            ans[end] = tmp;
            start++;
            end--;
        }

        return ans;
    }
}