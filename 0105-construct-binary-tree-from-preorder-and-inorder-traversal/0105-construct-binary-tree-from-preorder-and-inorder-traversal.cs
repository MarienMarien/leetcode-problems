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
    private int _preOrderIndex;
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length != inorder.Length)
            return null;
        _preOrderIndex = 0;
        var root = new TreeNode(preorder[0]);
        var rootId = GetInorderIndex(inorder, preorder[0]);
        RebuildTree(root, inorder[0..rootId], inorder[(rootId + 1)..], preorder);
        return root;
    }

    private void RebuildTree(TreeNode node, int[] left, int[] right, int[] preorder)
    {
        if (left.Length > 0) {
            _preOrderIndex++;
            node.left = new TreeNode(preorder[_preOrderIndex]);
            var nextNodeId = GetInorderIndex(left, preorder[_preOrderIndex]);
            RebuildTree(node.left, left[0..nextNodeId], left[(nextNodeId + 1)..], preorder);
        }
        if (right.Length > 0) { 
            _preOrderIndex++;
            node.right = new TreeNode(preorder[_preOrderIndex]);
            var nextNodeId = GetInorderIndex(right, preorder[_preOrderIndex]);
            RebuildTree(node.right, right[0..nextNodeId], right[(nextNodeId + 1)..], preorder);
        }
    }

    private int GetInorderIndex(int[] inorder, int target)
    {
        for (var i = 0; i < inorder.Length; i++) {
            if (inorder[i] == target)
                return i;
        }
        return -1;
    }
}