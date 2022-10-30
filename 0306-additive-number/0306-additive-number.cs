public class Solution {
    public bool IsAdditiveNumber(string num) {
        if (num.Length < 3)
                return false;
            for (var i = 0; i < num.Length - 2; i++) {
                var n1 = Int64.Parse(num.Substring(0, i + 1));
                var n2 = Int64.Parse(num.Substring(i + 1, 1));
                if (IsAdditive(n1, n2, num, i + 2))
                    return true;
                if (n1 == 0)
                    break;
            }
            return false;
        }

        private static bool IsAdditive(long n1, long n2, string num, int nextId)
        {
            if (nextId == num.Length)
                return true;
            for (var i = nextId; i < num.Length; i++) {
                var sum = n1 + n2;
                var sumStr = sum.ToString();
                if (num[i..].StartsWith(sumStr) && IsAdditive(n2, sum, num, i + sumStr.Length))
                    return true;
                else {
                    if (n2 == 0 || !Int64.TryParse(num[(nextId - 1)..(i + 1)], out n2))
                        break;
                }
            }
            return false;
    }
}