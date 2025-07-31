public class Solution {
    public int Candy(int[] ratings) {
        var minCandies = 0;
        var len = ratings.Length;
        var lastId = len - 1;
        var l2r = new int[len];
        l2r[0] = 1;
        var r2l = new int[len];
        r2l[lastId] = 1;
        for(var i = 1; i < len; i++)
        {
            l2r[i] = ratings[i] > ratings[i - 1] ? l2r[i - 1] + 1 : 1;
            r2l[lastId - i] = ratings[lastId - i] > ratings[lastId - i + 1] ? r2l[lastId - i + 1] + 1 : 1;
        }
        for(var i = 0; i < len; i++)
        {
            minCandies += Math.Max(l2r[i], r2l[i]);
        }
        return minCandies;
    }
}