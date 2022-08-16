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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var res = new Dictionary<int, IList<int>>();
        if (root == null)
            return res.Values.ToList();
        var q = new Queue<KeyValuePair<TreeNode, int>>();
        q.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
        while (q.Count > 0) {
            var curr = q.Dequeue();
            if (!res.ContainsKey(curr.Value))
                res.Add(curr.Value, new List<int>());
            res[curr.Value].Add(curr.Key.val);
            if (curr.Key.left != null)
                q.Enqueue(new KeyValuePair<TreeNode, int>(curr.Key.left, curr.Value - 1));
            if (curr.Key.right != null)
                q.Enqueue(new KeyValuePair<TreeNode, int>(curr.Key.right, curr.Value + 1));
        }

        return res.OrderBy(x => x.Key).Select(x => x.Value).ToList();
    }
}