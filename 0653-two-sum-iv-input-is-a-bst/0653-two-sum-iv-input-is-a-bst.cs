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
    private HashSet<int> _set;
    public bool FindTarget(TreeNode root, int k) {
        _set = new HashSet<int>();
        return DFS(root, k);
    }

    private bool DFS(TreeNode root, int k)
    {
        if (root == null)
            return false;
        if(_set.Contains(root.val))
            return true;
        _set.Add(k - root.val);
        var res = DFS(root.left, k);
        if (!res)
            res = DFS(root.right, k);
        return res;
}
}