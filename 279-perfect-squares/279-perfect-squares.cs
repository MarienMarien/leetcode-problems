public class Solution {
    public int NumSquares(int n) {
        var result = new List<int>();
            result.Add(0);
            while(result.Count <= n){
                var countedSqSize = result.Count;
                int tempMin = Int32.MaxValue;
                for (var j = 1; j * j <= countedSqSize; j++) {
                    tempMin = Math.Min(tempMin, result[countedSqSize - j*j] + 1);
                }
                result.Add(tempMin);
            }
            return result[n];
    }
}