public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var set = new HashSet<int>();
        Array.Sort(arr);
        var curr = 1;
        for(var i = 1; i < arr.Length; i++){
            if(arr[i] != arr[i-1]){
                if(set.Contains(curr))
                    return false;
                set.Add(curr);
                curr = 0;
            }
            curr++;
        }
        
        return !set.Contains(curr);
    }
}