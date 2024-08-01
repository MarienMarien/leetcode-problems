public class Solution {
    public int CountSeniors(string[] details) {
        var count = 0;
        foreach(var d in details)
        {
            var age1digit = d[11] - '0';
            if(age1digit > 6 || age1digit == 6 && d[12] - '0' > 0)
                count++;
        }
        return count;
    }
}