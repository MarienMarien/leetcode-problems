public class Solution {
    public int NextGreaterElement(int n) {
        if (n < 10)
            return -1;
        var num = n.ToString().ToCharArray();
        var i = num.Length - 2;
        while (i >= 0 && num[i] >= num[i + 1])
        {
            i--;
        }
        if (i < 0){
            return -1;
        }
        var j = num.Length - 1;
        while (j >= 0 && num[j] <= num[i]) {
            j--;
        }
        var tmp = num[i];
        num[i] = num[j];
        num[j] = tmp;
        var start = i + 1;
        var end = num.Length - 1;
        while (start < end) {
            var tmp1 = num[start];
            num[start] = num[end];
            num[end] = tmp1;
            start++;
            end--;
        }
        if (Int32.TryParse(new string(num), out int newN))
            return newN;
        return -1;
    }
}