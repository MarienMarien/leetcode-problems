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
    private IList<string> _paths;
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        _paths = new List<string>();
        ConstructPaths(root, new List<int>(){ root.val });
        return _paths;
    }

    private void ConstructPaths(TreeNode root, List<int> list)
    {
        if (root.left == null && root.right == null) {
            _paths.Add(string.Join("->", list));
            return;
        }
        if (root.left != null) {
            list.Add(root.left.val);
            ConstructPaths(root.left, list);
            list.RemoveAt(list.Count - 1);
        }
        if (root.right != null) {
            list.Add(root.right.val);
            ConstructPaths(root.right, list);
            list.RemoveAt(list.Count - 1);
        }
    }
}