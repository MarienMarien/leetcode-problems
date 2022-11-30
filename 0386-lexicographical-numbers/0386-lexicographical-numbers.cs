public class Solution {
    public IList<int> LexicalOrder(int n) {
        IList<int> res = new List<int>();
        FillRes(n, 1, res);
        return res;
    }

    private void FillRes(int n, int curr, IList<int> res)
    {
        if (curr > n || res.Count == n)
            return;
        res.Add(curr);
        if (curr * 10 <= n)
            FillRes(n, curr * 10, res);
        if(curr + 1 < ((curr / 10) + 1) * 10)
            FillRes(n, curr + 1, res);
    }
}