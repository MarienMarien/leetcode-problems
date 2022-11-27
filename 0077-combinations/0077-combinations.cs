public class Solution {
    private IList<IList<int>> _result;
    public IList<IList<int>> Combine(int n, int k)
    {
        _result = new List<IList<int>>();
        GenerateCombinations(n, k, new List<int>(), 1);
        return _result;
    }

    private void GenerateCombinations(int n, int k, IList<int> curr, int start)
    {
        if (curr.Count == k) { 
            _result.Add(new List<int>(curr));
            return;
        }
        if (start > n)
            return;
        for (var i = start; i <= n; i++) {
            curr.Add(i);
            GenerateCombinations(n, k, curr, i + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}