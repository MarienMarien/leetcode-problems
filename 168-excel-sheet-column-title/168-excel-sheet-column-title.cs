public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var sb = new StringBuilder();
        while (columnNumber > 0)
        {
            var rem = columnNumber % 26;
            if (rem == 0)
            {
                sb.Insert(0, 'Z');
                columnNumber = (columnNumber / 26) - 1;
            }
            else {
                sb.Insert(0, Convert.ToChar((rem - 1) + 'A'));
                columnNumber /= 26;
            }
        }

        return sb.ToString();
    }
}