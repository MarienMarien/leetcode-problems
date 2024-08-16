public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var map = new Dictionary<string, IDictionary<string,double>>();
        for (var i = 0; i < equations.Count; i++)
        {
            map.TryAdd(equations[i][0], new Dictionary<string, double>());
            map[equations[i][0]].Add(equations[i][1], values[i]);

            map.TryAdd(equations[i][1], new Dictionary<string, double>());
            map[equations[i][1]].Add(equations[i][0], 1 / values[i]);
        }

        var res = new double[queries.Count];

        for(var i = 0; i < queries.Count; i++)
        {
            var divident = queries[i][0];
            var divisor = queries[i][1];
            if (!map.ContainsKey(divisor) || !map.ContainsKey(divident))
            {
                res[i] = -1.0;
            }
            else if (divident.Equals(divisor))
            {
                res[i] = 1.0;
            }
            else
            {
                if (map[divident].ContainsKey(divisor))
                    res[i] = map[divident][divisor];
                else
                    res[i] = GetQueryResult(map, divident, divisor, 1.0, new HashSet<string>());
            }
        }

        return res;
    }

    private double GetQueryResult(Dictionary<string, IDictionary<string, double>> map, string curr, string divisor, double result, ISet<string> visited)
    {
        foreach (var node in map[curr])
        {
            if (visited.Contains(node.Key))
                continue;

            var currRes = result * node.Value;
            if (node.Key.Equals(divisor))
            {
                return currRes;
            }
            visited.Add(node.Key);
            var res = GetQueryResult(map, node.Key, divisor, currRes, visited);
            if (res >= 0)
                return res;
            visited.Remove(node.Key);
        }

        return -1;
    }
}