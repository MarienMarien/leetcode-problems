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
    private int _postOrderId;
    private int[] _inorder;
    private int[] _postorder;
    private IDictionary<int, int> _map;

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        _postOrderId = postorder.Length - 1;
        _postorder = postorder;
        _inorder = inorder;
        _map = new Dictionary<int, int>();
        for (var i = 0; i < inorder.Length; i++) {
            _map.Add(inorder[i], i);
        }
        return RecreateTree(0, inorder.Length - 1);
    }

    private TreeNode RecreateTree(int inordLeft, int inordRight)
    {
        if (inordLeft > inordRight)
            return null;
        var nodeVal = _postorder[_postOrderId];
        TreeNode node = new TreeNode(nodeVal);
        int id = _map[nodeVal];
        _postOrderId--;
        node.right = RecreateTree(id + 1, inordRight);
        node.left = RecreateTree(inordLeft, id - 1);
        return node;
    }
}