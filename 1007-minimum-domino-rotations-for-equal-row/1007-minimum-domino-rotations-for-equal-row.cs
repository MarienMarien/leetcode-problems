public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        var rotationsCount = CountRotations(tops[0], tops, bottoms);
        if (rotationsCount != -1 || tops[0] == bottoms[0])
            return rotationsCount;
        return CountRotations(bottoms[0], tops, bottoms);
    }

    private int CountRotations(int curr, int[] tops, int[] bottoms)
    {
        var countTop = 0;
        var countBottom = 0;
        for (var i = 0; i < tops.Length; i++) {
            if (tops[i] != curr && bottoms[i] != curr)
                return -1;
            if (tops[i] != curr)
                countTop++;
            if (bottoms[i] != curr)
                countBottom++;
        }
        return Math.Min(countTop, countBottom);
    }
}