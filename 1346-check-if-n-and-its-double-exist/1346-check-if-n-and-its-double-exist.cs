public class Solution {
    public bool CheckIfExist(int[] arr) {
        Array.Sort(arr, Comparer<int>.Create((x, y) => Math.Abs(x).CompareTo(Math.Abs(y))));
        var doubled = arr[0] * 2;
        var left = 0;
        var right = 1;
        while(right < arr.Length && left < arr.Length)
        {
            if(arr[right] == doubled)
                return true;
            if(Math.Abs(arr[right]) < Math.Abs(doubled))
                right++;
            else 
            {
                left++;
                doubled = arr[left] * 2;
            }
        }
        
        return false;
    }
}