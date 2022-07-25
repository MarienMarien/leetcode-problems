public class Solution {
    public string AddBinary(string a, string b) {
        if (b.Length > a.Length)
            return AddBinary(b, a);
        if (a.Length == 0)
            return b;
        if (b.Length == 0)
            return a;
        var sb = new StringBuilder();
        var carry = 0;
        var aId = a.Length - 1;
        var bId = b.Length - 1;
        while (aId >= 0)
        {
            var d1 = a[aId] - '0';
            var d2 = bId >= 0 ? b[bId] - '0' : 0;
            sb.Insert(0, (d1 + d2 + carry) % 2);
            carry = (d1 + d2 + carry) / 2;

            aId--;
            bId--;
        }
        if(carry > 0)
            sb.Insert(0, carry);
        return sb.ToString();
    }
}