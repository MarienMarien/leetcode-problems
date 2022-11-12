public class Solution {
    public string RemoveDigit(string number, char digit) {
        var last = -1;
        var toDelete = -1;
        var sb = new StringBuilder(number);
        for (var i = 0; i < number.Length; i++) {
            if (number[i] == digit) {
                last = i;
                if (i < number.Length - 1 && number[i + 1] > digit & toDelete < 0)
                    toDelete = i;

            }
        }
        if (toDelete < 0)
            toDelete = last;
        return sb.Remove(toDelete, 1).ToString();
    }
}