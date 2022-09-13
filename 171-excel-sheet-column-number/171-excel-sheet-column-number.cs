public class Solution {
    public int TitleToNumber(string columnTitle) {
        double res = 0;
        var k = 0;
        for (var i = columnTitle.Length - 1; i >= 0; i--) {
            var chId = columnTitle[i] - 'A' + 1;
            res += chId * Math.Pow(26, k);
            k++;
        }

        return (int)res;
    }
}