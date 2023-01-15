/**
 * // This is ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *     // Compares the sum of arr[l..r] with the sum of arr[x..y] 
 *     // return 1 if sum(arr[l..r]) > sum(arr[x..y])
 *     // return 0 if sum(arr[l..r]) == sum(arr[x..y])
 *     // return -1 if sum(arr[l..r]) < sum(arr[x..y])
 *     public int CompareSub(int l, int r, int x, int y) {}
 *
 *     // Returns the length of the array
 *     public int Length() {}
 * }
 */

class Solution {
    public int GetIndex(ArrayReader reader) {
        var arrLen = reader.Length();
        var start = 0;
        var end = arrLen - 1;
        while (start < end)
        {
            var mid = start + ((end - start) / 2);
            int comparison;
            if ((end - start) % 2 == 0)
                comparison = reader.CompareSub(start, mid, mid, end);
            else
                comparison = reader.CompareSub(start, mid, mid + 1, end);
            if (comparison > 0)
                end = mid;
            else if (comparison < 0)
                start = mid + 1;
            else
                return mid;
        }
        return start;
    }
}