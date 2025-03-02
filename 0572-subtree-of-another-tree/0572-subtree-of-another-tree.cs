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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            if(IsSubtreeDFS(curr, subRoot))
                return true;
            if(curr.left != null)
                q.Enqueue(curr.left);
            if(curr.right != null)
                q.Enqueue(curr.right);
        }

        return false;
    }

    private bool IsSubtreeDFS(TreeNode node, TreeNode subtreeNode)
    {
        if(node == subtreeNode)
            return true;
        if((node == null && subtreeNode != null) || (node != null && subtreeNode == null) || node.val != subtreeNode.val)
            return false;
        return IsSubtreeDFS(node.left, subtreeNode.left) && IsSubtreeDFS(node.right, subtreeNode.right);
    }
}