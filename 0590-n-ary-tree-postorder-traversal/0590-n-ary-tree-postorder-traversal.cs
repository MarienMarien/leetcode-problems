/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Postorder(Node root) {
        var traversal = new List<int>();
        if(root == null)
            return traversal;

        var treeStack = new Stack<Node>();
        var processed = new HashSet<Node>();

        treeStack.Push(root);
        while (treeStack.Count > 0)
        {
            var currTop = treeStack.Peek();
            if (!processed.Contains(currTop) && currTop.children.Count > 0)
            {
                for (var i = currTop.children.Count - 1; i >= 0; i--)
                {
                    treeStack.Push(currTop.children[i]);
                }
                processed.Add(currTop);
            }
            else {
                traversal.Add(currTop.val);
                treeStack.Pop();
            }
        }

        return traversal;
    }
}