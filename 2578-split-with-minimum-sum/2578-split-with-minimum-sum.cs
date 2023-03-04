public class Solution {
    public int SplitNum(int num) {
        var numStr = num.ToString().ToCharArray();
        Array.Sort(numStr);
        var num1 = new StringBuilder();
        var num2 = new StringBuilder();
        for (var i = 0; i < numStr.Length; i += 2) {
            num1.Append(numStr[i]);
            if (i + 1 < numStr.Length)
                num2.Append(numStr[i+1]);
        }
        return Int32.Parse(num1.ToString()) + Int32.Parse(num2.ToString());
    }
}