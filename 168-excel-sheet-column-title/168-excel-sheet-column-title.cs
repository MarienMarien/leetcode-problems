public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var sb = new StringBuilder();
        var curr = columnNumber;
        while (curr > 26) {
            curr -= 1;
            var newCurr = curr / 26;
            var letter = Convert.ToChar(curr - (newCurr * 26) + 'A');
            sb.Insert(0, letter);
            curr = newCurr;
        }
        sb.Insert(0, Convert.ToChar(curr - 1 + 'A'));


        return sb.ToString();
    }
}