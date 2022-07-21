public class Solution {
    private IList<IList<int>> res;
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        res = new List<IList<int>>();
        FillRes(candidates, target, 0, 0, new List<int>());
        return res.ToList();
    }

    private void FillRes(int[] candidates, int target, int currIdx, int sum, IList<int> curr)
    {
        for (var i = currIdx; i < candidates.Length; i++)
        {
            if (i > currIdx && candidates[i] == candidates[i - 1])
                continue;
            if (sum + candidates[i] == target)
            {
                curr.Add(candidates[i]);
                res.Add(new List<int>(curr));
                curr.RemoveAt(curr.Count - 1);
                return;
            }
            if (sum + candidates[i] < target)
            {
                curr.Add(candidates[i]);
                FillRes(candidates, target, i + 1, sum + candidates[i], curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}