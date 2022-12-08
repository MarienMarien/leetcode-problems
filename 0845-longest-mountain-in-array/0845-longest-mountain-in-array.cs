public class Solution {
    public int LongestMountain(int[] arr) {
        if (arr.Length < 3)
            return 0;
        var start = 0;
        int end;
        var max = 0;
        var lastId = arr.Length - 1;
        while (start < arr.Length) {
            end = start;
            if (end < lastId && arr[end] < arr[end + 1]) {
                while (end < lastId && arr[end] < arr[end + 1]) 
                    end++;
                if (end < lastId && arr[end] > arr[end + 1]) {
                    while (end < lastId && arr[end] > arr[end + 1]) 
                        end++;
                    max = Math.Max(max, end - start + 1);
                }
            }
            start = Math.Max(start + 1, end);
        }
        return max;
    }
}