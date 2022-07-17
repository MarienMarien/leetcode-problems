public class Solution {
    IList<IList<int>> res = new List<IList<int>>();
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
       Array.Sort(candidates);
        for (var i = 0; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
                continue;
            FindCombinations(candidates, i, target, candidates[i], new LinkedList<int>());
        }
        return res;
    }

    private bool FindCombinations(int[] candidates, int startPosition, int target, int currentSum, LinkedList<int> combination)
    {
        combination.AddLast(candidates[startPosition]);
        if (target - currentSum < 0)
        {
            combination.RemoveLast();
            return false;
        }

        if (target - currentSum == 0)
        {
            res.Add(new List<int>(combination));
            combination.RemoveLast();
            return true;
        }
        for (var i = startPosition; i < candidates.Length; i++)
        {
            if (currentSum + candidates[i] > target)
                break;
            FindCombinations(candidates, i, target, currentSum + candidates[i], combination);
        }
        if (combination.Count > 0)
            combination.RemoveLast();
        return true;
    }
}