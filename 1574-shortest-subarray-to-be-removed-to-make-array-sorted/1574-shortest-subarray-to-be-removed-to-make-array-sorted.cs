public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        var right = arr.Length - 1;
        while (right > 0 && arr[right] >= arr[right - 1])
            right--;
        var left = 0;
        var res = right;
        while (left < right && (left == 0 || arr[left - 1] <= arr[left]))
        {
            while (right < arr.Length && arr[left] > arr[right])
                right++;
            res = Math.Min(res, right - left - 1);
            left++;
        }

        return res;
    }
}