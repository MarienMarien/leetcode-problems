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
    private int _preId;
    private int _postId;
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        return Construct(preorder, postorder);
    }

    private TreeNode Construct(int[] preorder, int[] postorder)
    {
        var node = new TreeNode(preorder[_preId]);
        _preId++;

        if(node.val != postorder[_postId])
        {
            node.left = Construct(preorder, postorder);
        }

        if(node.val != postorder[_postId])
        {
            node.right = Construct(preorder, postorder);
        }

        _postId++;

        return node;
    }
}