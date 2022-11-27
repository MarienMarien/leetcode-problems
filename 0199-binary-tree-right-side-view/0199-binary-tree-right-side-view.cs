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
    public IList<int> RightSideView(TreeNode root) {
        IList<int> res = new List<int>();
        if (root == null)
            return res;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var layersize = 1;
        var nextLayerSize = 0;
        while (q.Count > 0) {
            var curr = q.Dequeue();
            layersize--;
            res.Add(curr.val);
            if (curr.right != null)
            {
                q.Enqueue(curr.right);
                nextLayerSize++;
            }
            if (curr.left != null)
            {
                q.Enqueue(curr.left);
                nextLayerSize++;
            }
            if (layersize > 0) {
                while (layersize > 0)
                {
                    var tmp = q.Dequeue();
                    if (tmp.right != null)
                    {
                        q.Enqueue(tmp.right);
                        nextLayerSize++;
                    }
                    if (tmp.left != null)
                    {
                        q.Enqueue(tmp.left);
                        nextLayerSize++;
                    }
                    layersize--;
                }
            }
            layersize = nextLayerSize;
            nextLayerSize = 0;
        }
        return res;
    }
}