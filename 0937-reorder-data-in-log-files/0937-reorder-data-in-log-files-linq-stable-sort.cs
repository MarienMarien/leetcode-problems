public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        return logs.Order(Comparer<string>.Create((x, y) =>
        {
            var splittedX = x.Split(' ', 2);
            var isXDigit = char.IsDigit(splittedX[1][0]);
            var contentX = isXDigit ? "1" : $"0 {splittedX[1]}";

            var splittedY = y.Split(' ', 2);
            var isYDigit = char.IsDigit(splittedY[1][0]);
            var contentY = isYDigit ? "1" : $"0 {splittedY[1]}";

            if (contentX == contentY && contentX[0] == '0')
            {
                return string.Compare(splittedX[0], splittedY[0]);
            }

            return string.Compare(contentX, contentY);
        })).ToArray();
    }
}