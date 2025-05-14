/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    private bool _pNodeFound;
    private TreeNode _successor;
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        _successor = null;
        FindSuccessor(root, p);
        return _successor;
    }

    private void FindSuccessor(TreeNode node, TreeNode p)
    {
        if(node == null)
            return;
        if(node == p)
        {
            _pNodeFound = true;
            if(node.right != null)
            {
                var candidate = node.right;
                while(candidate.left != null)
                {
                    candidate = candidate.left;
                }
                _successor = candidate;
            }
            return;
        }
        if(!_pNodeFound)
            FindSuccessor(node.left, p);
        if(_pNodeFound)
        {
            if(_successor == null)
                _successor = node;
            return;
        }
        FindSuccessor(node.right, p);
    }
}