public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        Array.Sort(target);
        Array.Sort(arr);

        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] != target[i])
                return false;
        }

        return true;
    }
}