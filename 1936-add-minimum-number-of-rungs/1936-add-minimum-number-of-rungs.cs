public class Solution {
    public int AddRungs(int[] rungs, int dist) {
        int currRung = 0;
        int additionalRungs = 0;
        foreach (int rung in rungs) {
            int currDist = rung - currRung;
            if (currDist > dist) {
                additionalRungs += (int)Math.Ceiling(currDist / (decimal)dist) - 1;
            }
            currRung = rung;
        }
        return additionalRungs;
    }
}