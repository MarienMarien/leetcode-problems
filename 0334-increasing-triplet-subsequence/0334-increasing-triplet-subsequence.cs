public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        var first = Int32.MaxValue;
        var second = Int32.MaxValue;
        foreach (var n in nums) {
            if (n <= first)
            {
                first = n;
            }
            else if (n <= second)
            {
                second = n;
            }
            else {
                return true;
            }
        }
        return false;
    }
}