/**
 * Definition for Node.
 * public class Node {
 *     public int val;
 *     public Node left;
 *     public Node right;
 *     public Node random;
 *     public Node(int val=0, Node left=null, Node right=null, Node random=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *         this.random = random;
 *     }
 * }
 */

public class Solution {
    private IDictionary<Node, NodeCopy> _nodeToCopy;

    public NodeCopy CopyRandomBinaryTree(Node root)
    {
        _nodeToCopy = new Dictionary<Node, NodeCopy>();
        NodeCopy copy = GetCopy(root);
        MapRandom(root);
        return copy;
    }

    private void MapRandom(Node root)
    {
        if (root == null)
            return;
        var nodeCopy = _nodeToCopy[root];
        if(root.random != null)
            nodeCopy.random = _nodeToCopy[root.random];
        MapRandom(root.left);
        MapRandom(root.right);
    }

    private NodeCopy GetCopy(Node root)
    {
        if (root == null)
            return null;
        NodeCopy copy = new NodeCopy(root.val);
        copy.left = GetCopy(root.left);
        copy.right = GetCopy(root.right);
        _nodeToCopy.Add(root, copy);
        return copy;
    }
}