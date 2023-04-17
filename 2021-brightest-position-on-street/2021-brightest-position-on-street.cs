public class Solution {
    public int BrightestPosition(int[][] lights) {
        var map = new SortedDictionary<int, int[]>();
        foreach (var l in lights) {
            var left = l[0] - l[1];
            var right = l[0] + l[1];
            map.TryAdd(left, new int[2]);
            map.TryAdd(right, new int[2]);
            map[left][0]++;
            map[right][1]++;
        }
        var max = 0;
        var curr = 0;
        var brightest = 0;
        foreach (var entry in map) {
            curr += map[entry.Key][0];
            if (curr > max) {
                max = curr;
                brightest = entry.Key;
            }
            curr -= map[entry.Key][1];
        }
        return brightest;
    }
}