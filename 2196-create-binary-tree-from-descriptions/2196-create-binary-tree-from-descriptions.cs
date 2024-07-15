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
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var children = new HashSet<int>();
        var nodes = new Dictionary<int,TreeNode>();
        foreach (var d in descriptions)
        {
            if (!nodes.TryGetValue(d[0], out TreeNode currNode)) 
            {
                currNode = new TreeNode(d[0]);
                nodes.Add(d[0], currNode);
            }

            if (!nodes.TryGetValue(d[1], out TreeNode child))
            {
                child= new TreeNode(d[1]);
                nodes.Add(d[1], child);
            }

            if (d[2] == 1)
            {
                currNode.left = child;
            }
            else {
                currNode.right = child;
            }

            if(!children.Contains(child.val))
                children.Add(child.val);
        }

        foreach (var node in nodes)
        {
            if (!children.Contains(node.Key))
                return node.Value;
        }

        return null;
    }
}