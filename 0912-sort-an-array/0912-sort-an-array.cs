public class Solution {
    public int[] SortArray(int[] nums) {
        return QuickSort(nums, 0, nums.Length - 1);
    }

    private void Swap(int[] arr, int i, int j) {
        var tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    private int Partition(int[] arr, int start, int end) {
        var pivot = arr[end];
        var id = start - 1;
        for (var i = start; i <= end - 1; i++) {
            if (arr[i] < pivot) {
                id++;
                Swap(arr, id, i);
            }
        }
        Swap(arr, id + 1, end);
        return id + 1;
    }
    private int[] QuickSort(int[] nums, int start, int end)
    {
        if (start < end) {
            var partitionId = Partition(nums, start, end);
            nums = QuickSort(nums, start, partitionId - 1);
            return QuickSort(nums, partitionId + 1, end);
        }
        return nums;
    }
}