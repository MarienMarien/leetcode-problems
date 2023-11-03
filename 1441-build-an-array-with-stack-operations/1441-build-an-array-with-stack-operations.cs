public class Solution {
    public IList<string> BuildArray(int[] target, int n) {
        const string PUSH = "Push";
        const string POP = "Pop";

        var res = new List<string>();
        var nextTarget = 1;

        foreach (var t in target)
        {
            if (t != nextTarget)
            {
                var diff = t - nextTarget;
                for (var i = 0; i < diff; i++)
                {
                    res.Add(PUSH);
                    res.Add(POP);
                }
            }
            nextTarget = t + 1;
            res.Add(PUSH);
        }

        return res;
    }
}