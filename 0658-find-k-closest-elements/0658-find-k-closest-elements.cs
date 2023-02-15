public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var start = 0; 
        var end = arr.Length - 1;
        while (end - start >= k) {
            if (Math.Abs(arr[end] - x) < Math.Abs(arr[start] - x))
                start++;
            else
                end--;
        }

        var res = new List<int>();
        for (var i = start; i <= end; i++) {
            res.Add(arr[i]);
        }
        return res;
    }
}