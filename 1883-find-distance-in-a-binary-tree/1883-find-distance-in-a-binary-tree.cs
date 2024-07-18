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
    private ISet<int> _targets;
    public int FindDistance(TreeNode root, int p, int q)
    {
        if (p == q)
            return 0;

        _targets = new HashSet<int> { p, q };
        (_, int distance) = GetDistance(root);
        return distance;
    }

    private (bool found, int distance) GetDistance(TreeNode node)
    {
        if (node == null)
            return (false, 0);

        // left
        (bool foundL, int distanceL) = GetDistance(node.left);

        // right
        (bool foundR, int distanceR) = GetDistance(node.right);

        var found = foundL || foundR;
        var pathLen = distanceL + distanceR;

        if (distanceL > 0 && distanceR > 0)
        {
            return (true, pathLen);
        }

        if (_targets.Contains(node.val))
        {
            if (distanceL > 0 || distanceR > 0)
                found = true;
            else
                pathLen += 1;
        }
        else if (!found && (distanceR > 0 || distanceL > 0))
            pathLen += 1;

        return (found, pathLen);
    }
}