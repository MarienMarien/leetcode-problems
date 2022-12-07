public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        if(arr.Length == 0)
            return Array.Empty<int>();
        var arrCopy = new int[arr.Length];
        Array.Copy(arr, arrCopy, arr.Length);
        Array.Sort(arrCopy);
        var curr = arr[0];
        var dict = new Dictionary<int, int>();
        var rank = 1;
        foreach(var a in arrCopy){
            if(!dict.ContainsKey(a)){
                dict.Add(a, rank);
                rank++;
            }
        }
        var res = new int[arr.Length];
        for(var i = 0; i < res.Length; i++){
            res[i] = dict[arr[i]];
        }
        return res;
    }
}