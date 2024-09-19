public class Solution {
    private IDictionary<char, Func<int, int, int>> _operations = new Dictionary<char, Func<int, int, int>>{
        { '-', (x, y) => x - y },
        { '+', (x, y) => x + y },
        { '*', (x, y) => x * y }
    };

    public IList<int> DiffWaysToCompute(string expression)
    {
        var res = new List<int>();
        if (expression.Length == 0)
            return res;
        if (expression.Length == 1)
        {
            res.Add(Int32.Parse(expression));
            return res;
        }
        if (expression.Length == 2 && char.IsDigit(expression[0]))
        {
            res.Add(Int32.Parse(expression));
            return res;
        }

        for (var i = 0; i < expression.Length; i++)
        {
            if (char.IsDigit(expression[i]))
                continue;

            var left = DiffWaysToCompute(expression[0..i]);
            var right = DiffWaysToCompute(expression[(i + 1)..]);
            var operation = _operations[expression[i]];
            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    res.Add(operation(l, r));
                }
            }
        }

        return res;
    }
}