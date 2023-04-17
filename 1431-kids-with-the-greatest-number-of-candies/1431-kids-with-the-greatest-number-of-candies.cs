public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        var greatest = 0;
        foreach (var c in candies) {
            greatest = Math.Max(greatest, c);
        }
        IList<bool> res = new List<bool>();
        foreach (var c in candies) {
            res.Add(c + extraCandies >= greatest);
        }
        return res;
    }
}