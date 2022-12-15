public class Solution {
    private IList<IList<int>> _result;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        _result = new List<IList<int>>();
        FillRes(graph, new List<int>(), 0);
        return _result;
    }

    private void FillRes(int[][] graph, List<int> list, int currNode)
    {
        list.Add(currNode);
        if (currNode == graph.Length - 1) {
            _result.Add(new List<int>(list));
            return;
        }
        
        foreach (var node in graph[currNode]) { 
            FillRes(graph, list, node);
            list.RemoveAt(list.Count - 1);
        }
    }
}