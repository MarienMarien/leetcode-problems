public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        bool[] hasIncomingEdge= new bool[n];
        foreach (IList<int> edge in edges) {
            hasIncomingEdge[edge[1]] = true;
        }
        IList<int> res = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!hasIncomingEdge[i])
                res.Add(i);
        }
        return res;
    }
}