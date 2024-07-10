public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        var oddsCount = 0;

        foreach(var a in arr)
        {
            if(a % 2 != 0)
                oddsCount++;
            else
                oddsCount = 0;
            
            if(oddsCount == 3)
                return true;
        }

        return false;
    }
}