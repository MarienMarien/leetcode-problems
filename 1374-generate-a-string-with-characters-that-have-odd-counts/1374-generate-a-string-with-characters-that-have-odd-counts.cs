public class Solution {
    public string GenerateTheString(int n) {
        var result = new StringBuilder();
            var letA = 'a';
            var letB = 'b';
            var isEven = n % 2 == 0;// not odd
            if (isEven) {
                result.Append(letB);
            }
            var upperbound = isEven ? n - 1 : n;
            for (var i = 0; i < upperbound; i++) {
                result.Append(letA);
            }

            return result.ToString();
    }
}