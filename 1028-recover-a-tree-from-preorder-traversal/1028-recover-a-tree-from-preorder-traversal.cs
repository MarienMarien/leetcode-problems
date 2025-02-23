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
    private int _tId;
    public TreeNode RecoverFromPreorder(string traversal) {
        _tId = 0;
        return Recover(traversal, 0);
    }

    private TreeNode Recover(string traversal, int currLevel)
    {
        if(_tId >= traversal.Length)
            return null;

        var nextId = _tId;
        var nextNodeLevel = 0;
        while(_tId < traversal.Length && traversal[nextId] == '-')
        {
            nextId++;
            nextNodeLevel++;
        }

        if(nextNodeLevel != currLevel)
            return null;

        _tId = nextId;
        var nodeValue = 0;
        while(_tId < traversal.Length && char.IsDigit(traversal[_tId]))
        {
            nodeValue = nodeValue * 10 + (traversal[_tId] - '0');
            _tId++;
        }
        var node = new TreeNode(nodeValue);
        node.left = Recover(traversal, currLevel + 1);
        node.right = Recover(traversal, currLevel + 1);

        return node;
    }
}