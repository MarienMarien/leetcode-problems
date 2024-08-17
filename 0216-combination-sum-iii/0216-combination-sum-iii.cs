public class Solution {
    private IList<IList<int>> _combinations;
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        _combinations = new List<IList<int>>();
        FindCombinations(1, 0, new List<int>(), k, n);
        return _combinations;
    }

    private void FindCombinations(int startFrom, int currSum, IList<int> currList, int k, int n)
    {
        if(n == 0 && k == 0)
            _combinations.Add(new List<int>(currList));
        
        if (k <= 0)
            return;
            
        for(var i = startFrom; i < 10; i++) 
        {
            if(n - i < 0)
                break;
            currList.Add(i);

            FindCombinations(i + 1, currSum, currList, k - 1, n - i);

            currList.RemoveAt(currList.Count - 1);
        }
    }
}