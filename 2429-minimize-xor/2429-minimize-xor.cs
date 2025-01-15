public class Solution {
    public int MinimizeXor(int num1, int num2) {
        var num1BinStr = Convert.ToString(num1, 2);
        var num2BinStr = Convert.ToString(num2, 2);
        var num2OnBitCount = 0;
        foreach (var ch in num2BinStr)
        {
            if (ch == '1')
                num2OnBitCount++;
        }
        var minXorStr = new char[Math.Max(num1BinStr.Length, num2OnBitCount)];
        minXorStr[0] = '1';
        num2OnBitCount--;
        var num1BinStrId = num1BinStr.Length - minXorStr.Length;
        for (var i = 1; i < minXorStr.Length; i++)
        {
            num1BinStrId++;
            if (num1BinStrId >= 0 && num1BinStr[num1BinStrId] == '1' && num2OnBitCount > 0)
            {
                minXorStr[i] = '1';
                num2OnBitCount--;
            }
            else
                minXorStr[i] = '0';
        }

        if (num2OnBitCount > 0)
        {
            for (var i = minXorStr.Length - 1; i >= 0; i--)
            {
                if (num2OnBitCount == 0)
                    break;
                if (minXorStr[i] == '1')
                    continue;
                minXorStr[i] = '1';
                num2OnBitCount--;
            }
        }

        return Convert.ToInt32(new string(minXorStr), 2);
    }
}