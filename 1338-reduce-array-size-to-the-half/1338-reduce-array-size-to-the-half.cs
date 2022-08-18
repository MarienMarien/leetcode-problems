public class Solution {
    public int MinSetSize(int[] arr) {
        var median = Math.Ceiling(arr.Length / 2.0);
        Array.Sort(arr);
        var reps = new List<int>();
        var repsCnt = 0;
        var curr = arr[0];
        for (var i = 0; i < arr.Length; i++) {
            if (arr[i] != curr) { 
                reps.Add(repsCnt);
                repsCnt = 0;
                curr = arr[i];
            }
            repsCnt++;
        }
        reps.Add(repsCnt);
        var res = 1;
        reps = reps.OrderByDescending(x => x).ToList();
        var currSum = reps[0];
        while (res < reps.Count && currSum < median) {
            currSum += reps[res];
            res++;
        }

        return res;
    }
}