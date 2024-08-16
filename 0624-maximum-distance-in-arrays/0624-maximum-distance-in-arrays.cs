public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        var distance = Int32.MinValue;
        var min = arrays[0][0];
        var max = arrays[0][^1];

        for (var i = 1; i < arrays.Count; i++)
        {
            distance = Math.Max(distance, Math.Max(Math.Abs(max - arrays[i][0]), Math.Abs(arrays[i][^1] - min)));

            min = Math.Min(min, arrays[i][0]);
            max = Math.Max(max, arrays[i][^1]);
        }

        return distance;
    }
}