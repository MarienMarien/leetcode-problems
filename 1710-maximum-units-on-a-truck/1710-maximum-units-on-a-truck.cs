public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();
        var maxUnits = 0;
        var i = 0;
        while (i < boxTypes.Length && truckSize > 0){
            var curr = boxTypes[i];
            var boxCnt = curr[0];
            if (boxCnt <= truckSize)
            {
                truckSize -= boxCnt;

            }
            else {
                boxCnt = truckSize;
                truckSize = 0;
            }
            maxUnits += curr[1] * boxCnt;
            i++;
        }

        return maxUnits;
    }
}