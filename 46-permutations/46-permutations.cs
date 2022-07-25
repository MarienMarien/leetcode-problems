public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        Backtrack(nums.Length, nums, res, 0);
        return res;
    }

    private void Backtrack(int length, int[] nums, IList<IList<int>> res, int start)
    {
        if (start == length) {
            res.Add(new List<int>(nums));
        }
        for (var i = start; i < length; i++) {
            Swap(nums, start, i);
            Backtrack(length, nums, res, start + 1);
            Swap(nums, start, i);
        }
    }

    private void Swap(int[] arr, int idFrom, int idTo) {
        if (idFrom == idTo)
            return;
        var tmp = arr[idTo];
        arr[idTo] = arr[idFrom];
        arr[idFrom] = tmp;
    }
}