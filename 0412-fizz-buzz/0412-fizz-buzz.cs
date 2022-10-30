public class Solution {
    public IList<string> FizzBuzz(int n) {
        IList<string> res = new List<string>();
        const string fizz = "Fizz";
        const string buzz = "Buzz";
        for (var i = 1; i <= n; i++) {
            var sb = new StringBuilder();
            var divBy3 = i % 3 == 0;
            var divBy5 = i % 5 == 0;
            if (divBy3)
                sb.Append(fizz);
            if (divBy5)
                sb.Append(buzz);
            if(!divBy3 && ! divBy5) 
                sb.Append(i);
            res.Add(sb.ToString());
        }

        return res;
    }
}