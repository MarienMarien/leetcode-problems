public class Solution {
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
        var totalArea = (ax2 - ax1) * (ay2 - ay1) + (bx2 - bx1) * (by2 - by1);
            var xOverlap = Math.Min(ax2, bx2) - Math.Max(ax1, bx1);
            var yOverlap = Math.Min(ay2, by2) - Math.Max(ay1, by1);
            var overlap = xOverlap > 0 && yOverlap > 0 ? xOverlap * yOverlap : 0;
            return totalArea - overlap;
    }
}