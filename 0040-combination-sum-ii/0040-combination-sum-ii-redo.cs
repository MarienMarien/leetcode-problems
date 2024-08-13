public class Solution {
    private IList<IList<int>> _combinations;
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        _combinations = new List<IList<int>>();
        Array.Sort(candidates);
        FindCombinations(candidates, 0, target, new List<int>()) ;
        return _combinations;
    }

    private void FindCombinations(int[] candidates, int startId, int target, IList<int> currCombination)
    {
        if (target < 0)
            return;
        if (target == 0)
        {
            _combinations.Add(new List<int>(currCombination));
            return;
        }

        for (var i = startId; i < candidates.Length; i++)
        {
            if (i > startId && candidates[i] == candidates[i - 1])
                continue;
            currCombination.Add(candidates[i]);
            FindCombinations(candidates, i + 1, target - candidates[i], currCombination);
            currCombination.RemoveAt(currCombination.Count - 1);
        }
    }
}