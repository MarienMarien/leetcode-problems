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
    public int MaxDepth(Node root) {
        if(root == null)
            return 0;

        var q = new Queue<Node>();
        q.Enqueue(root);

        var depth = 0;
        var layerSize = 1;

        while(q.Count > 0){
            var curr = q.Dequeue();
            layerSize--;
            foreach(var c in curr.children){
                q.Enqueue(c);
            }

            if(layerSize == 0){
                depth++;
                layerSize = q.Count;
            }
        }

        return depth;
    }
}