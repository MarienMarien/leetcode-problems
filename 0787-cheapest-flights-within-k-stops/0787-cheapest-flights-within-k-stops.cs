public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var dist = new int[n];
        Array.Fill(dist, Int32.MaxValue);
        dist[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            var tmp = new int[n];
            Array.Copy(dist, tmp, n);
            foreach (var f in flights)
            {
                if (dist[f[0]] != Int32.MaxValue)
                {
                    tmp[f[1]] = Math.Min(tmp[f[1]], dist[f[0]] + f[2]);
                }
            }
            dist = tmp;
        }
        return dist[dst] == Int32.MaxValue? -1 : dist[dst];
    }
}