public class Solution {
    public string CountAndSay(int n) {
        var digits = GetDigits(n);
        return string.Join("", digits);
    }

    private IList<int> GetDigits(int n)
    {
        var res = new List<int> { 1 };
        for(var turn = 1; turn < n; turn++)
        {
            var next = new List<int>();
            var count = 1;
            var prev = res[0];
            for(var i = 1; i < res.Count; i++)
            {
                if(res[i] == prev)
                {
                    count++;
                    continue;
                }
                next.Add(count);
                next.Add(prev);
                prev = res[i];
                count = 1;
            }
            next.Add(count);
            next.Add(prev);
            res = next;
        }

        return res;
    }
}