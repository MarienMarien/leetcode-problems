public class Solution {
    private IList<int> _result;
    public IList<int> LexicalOrder(int n)
    {
        _result = new List<int>();
        GenerateAllNumbers(0, n);

        return _result;
    }

    private void GenerateAllNumbers(int num, int n)
    {
        if (num > n)
            return;
        for (var i = 0; i <= 9; i++)
        {
            var nextNum = num + i;
            if (nextNum > 0 && nextNum <= n)
            {
                _result.Add(nextNum);
                GenerateAllNumbers(nextNum * 10, n);
            }

        }
    }
}