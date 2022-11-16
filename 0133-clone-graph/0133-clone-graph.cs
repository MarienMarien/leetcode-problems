/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return null;
        var map = new Dictionary<Node, Node>();
        var q = new Queue<Node>();
        var clone = new Node(node.val, new List<Node>());
        map.Add(node, clone);
        q.Enqueue(node);
        while (q.Count > 0) {
            var currNode = q.Dequeue();
            var currClone = map[currNode];
            var neighb = currNode?.neighbors;
            foreach (var nb in neighb) {
                if (!map.ContainsKey(nb))
                {
                    var newNode = new Node(nb.val, new List<Node>());
                    map.Add(nb, newNode);
                    q.Enqueue(nb);
                }
                currClone.neighbors.Add(map[nb]);
            }
            }
        return clone;
    }
}