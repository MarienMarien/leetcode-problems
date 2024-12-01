public class Solution {
    public bool CheckIfExist(int[] arr) {
        var set = new HashSet<int>();
        foreach(var a in arr)
        {
            if(set.Count > 0 && set.Contains(a))
                return true;
            var doubled = a * 2;
            var halfed = a % 2 == 0 ? a / 2 : -1;
            set.Add(doubled);
            if(halfed >= 0)
                set.Add(halfed);
        }

        return false;
    }
}