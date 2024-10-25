/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        var pAncestors = new HashSet<Node>();
        var pCopy = p;
        while (pCopy.parent != null) { 
            pAncestors.Add(pCopy);
            pCopy = pCopy.parent;
        }

        var qCopy = q;
        while (qCopy.parent != null && !pAncestors.Contains(qCopy))
        {
            qCopy = qCopy.parent;
        }

        return qCopy;
    }
}