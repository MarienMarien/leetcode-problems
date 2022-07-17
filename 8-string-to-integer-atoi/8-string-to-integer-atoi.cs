public class Solution {
    public int MyAtoi(string s) {
        if (s == "")
                return 0;
            var res = 0;
            var signKoef = 0;
            var i = 0;
            while (i < s.Length && s[i] == ' ')
            {
                i++;
            }
            while (i < s.Length) {
                if (s[i] == ' ') 
                    break;
                if (s[i] == '-' && signKoef == 0) {
                    i++;
                    signKoef = -1;
                    while (i < s.Length && s[i] == 0)
                    {
                        i++;
                    }
                    continue;
                }
                if (s[i] == '+' && signKoef == 0) {
                    signKoef = 1;
                    i++;
                    while (i < s.Length && s[i] == 0)
                    {
                        i++;
                    }
                    continue;
                }
                if (!Char.IsDigit(s[i]))
                    break;
                if (signKoef == 0)
                    signKoef = 1;
                if (res == 0 && s[i] == 0) {
                    while (i < s.Length && s[i] == 0)
                    {
                        i++;
                    }
                    continue;
                }
                var nextDigit = Int32.Parse(s[i].ToString());
                if (res > Int32.MaxValue / 10 || (res == Int32.MaxValue / 10 && nextDigit > 7))
                    return signKoef == -1 ? int.MinValue : int.MaxValue;
                res = res * 10 + nextDigit;
                i++;
            }
            return res * (signKoef == 0 ? 1 : signKoef);
    }
}