public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        var logWithId = new (int id, string val)[logs.Length];
        for (var i = 0; i < logs.Length; i++)
        {
            logWithId[i] = (i, logs[i]);
        }

        Array.Sort(logWithId, logs, new LogComparer());
        return logs;
    }

    public class LogComparer : IComparer<(int id, string val)>
    {
        public int Compare((int id, string val) x, (int id, string val) y)
        {
            var splittedX = x.val.Split(' ', 2);
            var isXDigit = char.IsDigit(splittedX[1][0]);
            var contentX = isXDigit ? "1" : $"0 {splittedX[1]}";

            var splittedY = y.val.Split(' ', 2);
            var isYDigit = char.IsDigit(splittedY[1][0]);
            var keyY = isYDigit ? "1" : $"0 {splittedY[1]}";

            if(isXDigit && isYDigit)
                return x.id.CompareTo(y.id);

            if (contentX == keyY && contentX[0] == '0')
            {
                return string.Compare(splittedX[0], splittedY[0]);
            }

            return string.Compare(contentX, keyY);
        }
    }
}