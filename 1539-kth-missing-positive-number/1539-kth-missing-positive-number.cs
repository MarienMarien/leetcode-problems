public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        var start = 0;
        var end = arr.Length - 1;
        while (start <= end) {
            var mid = (start + end) / 2;
            if (arr[mid] - mid - 1 < k)
            {
                start = mid + 1;
            }
            else {
                end = mid - 1;
            }
        }
        return start + k;
    }
}