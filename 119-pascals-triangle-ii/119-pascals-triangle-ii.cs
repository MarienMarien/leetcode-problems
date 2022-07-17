public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var defaultElement = 1;
            IList<int> result = new List<int>(rowIndex + 1);
            result.Add(defaultElement);
            for (var i = 0; i < rowIndex; i++) {
                for (var k = i; k > 0; k--) {
                    result[k] = result[k] + result[k - 1];
                }
                result.Add(defaultElement);
            }
            return result;
    }
}