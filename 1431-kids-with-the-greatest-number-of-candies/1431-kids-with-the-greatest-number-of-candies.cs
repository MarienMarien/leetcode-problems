public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        IList<bool> res = new List<bool>();
        var len = candies.Length;
        var withExtra = new int[len];
        var maxCandies = 0;
        for (var i = 0; i < candies.Length; i++) {
            withExtra[i] = candies[i] + extraCandies;
            maxCandies = Math.Max(maxCandies, candies[i]);
        }

        for (var i = 0; i < candies.Length; i++)
        {
            res.Add(withExtra[i] >= maxCandies);
        }

        return res;
    }
}