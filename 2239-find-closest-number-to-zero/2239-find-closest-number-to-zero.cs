public class Solution {
    public int FindClosestNumber(int[] nums) {
        var min = Int32.MaxValue;
        foreach(var n in nums){
            if(n == 0)
                return 0;
            var minAbs = Math.Abs(min);
            var currAbs = Math.Abs(n);
            if(minAbs == currAbs && min != n)
                min = minAbs;
            else if(currAbs < minAbs)
                min = n;
        }
        return min;
    }
}