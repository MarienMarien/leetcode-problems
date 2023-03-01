public class Solution {
    public int[] SortArray(int[] nums) {
        return MergeSort(nums, 0, nums.Length - 1);
    }

    private int[] MergeSort(int[] nums, int start, int end)
    {
        if (start < end) {
            var mid = (start + end) / 2;
            MergeSort(nums, start, mid);
            MergeSort(nums, mid + 1, end);

            Merge(nums, start, mid, end);
        }
        return nums;
    }

    private void Merge(int[] nums, int start, int mid, int end)
    {
        var len1 = mid - start + 1;
        var len2 = end - mid;

        var leftArr = new int[len1];
        var rightArr = new int[len2];
        for (var i = 0; i < len1; i++) {
            leftArr[i] = nums[start + i];
        }
        for (var i = 0; i < len2; i++)
        {
            rightArr[i] = nums[mid + 1 + i];
        }

        var leftId = 0;
        var rightId = 0;
        var numsId = start;
        while (leftId < len1 && rightId < len2) {
            if (leftArr[leftId] <= rightArr[rightId])
            {
                nums[numsId] = leftArr[leftId++];
            }
            else {
                nums[numsId] = rightArr[rightId++];
            }
            numsId++;
        }
        while(leftId < len1)
            nums[numsId++] = leftArr[leftId++];
        while (rightId < len2)
            nums[numsId++] = rightArr[rightId++];
    }
}