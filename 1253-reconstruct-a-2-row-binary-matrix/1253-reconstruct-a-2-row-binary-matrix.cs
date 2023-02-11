public class Solution {
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) {
        var res = new List<IList<int>>();
        var totalSum = 0;
        var twoCount = 0;
        foreach (var cs in colsum)
        {
            totalSum += cs;
            if (cs == 2)
                twoCount++;
        }
        if (upper + lower != totalSum || twoCount > Math.Min(upper, lower))
            return res;
        res.Add(new List<int>());
        res.Add(new List<int>());
        var mainRow = upper >= lower ? 0 : 1;
        var otherRow = upper >= lower ? 1 : 0;
        var counter = Math.Max(upper, lower) - twoCount;
        foreach (var cs in colsum) {
            if (counter == 0)
            {
                var tmp = otherRow;
                otherRow = mainRow;
                mainRow = tmp;
                counter--;
            }
            var mainRowVal = 1;
            var otherRowVal = 0;
            if (cs != 1)
            {
                mainRowVal = cs / 2;
                otherRowVal = cs / 2;
            }
            res[mainRow].Add(mainRowVal);
            res[otherRow].Add(otherRowVal);
            if(cs == 1)
                counter--;
        }
        return res;
    }
}