public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var sb = new StringBuilder();
        var curr = columnNumber;
        while (curr > 26)
        {
            curr -= 1;
            var newCurr = curr / 26;
            var letter = Convert.ToChar(curr - (newCurr * 26) + 'A');
            sb.Append(letter);
            curr = newCurr;
        }
        sb.Append(Convert.ToChar(curr - 1 + 'A'));

        int start = 0, end = sb.Length - 1;
        while (start < end) {
            var tmp = sb[start];
            sb[start] = sb[end];
            sb[end] = tmp;
            start++;
            end--;
        }
        return sb.ToString();
    }
}