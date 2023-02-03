public class Solution {
    public string Convert(string s, int numRows) {
       if (numRows == 1 || numRows >= s.Length)
            return s;
        var len = s.Length;
        var sb = new StringBuilder();
        for (var row = 0; row < Math.Min(numRows, s.Length); row++) {
            var sId = row;
            sb.Append(s[sId]);
            while (sId < s.Length) {
                var step = (numRows - row) + ((numRows - row) - 2);
                sId += step;
                if (step != 0 && sId < len)
                    sb.Append(s[sId]);
                if (row > 0) {
                    sId += row * 2;
                    if (sId >= len)
                        break;
                    sb.Append(s[sId]);
                }
            }
        }
        return sb.ToString();
    }
}