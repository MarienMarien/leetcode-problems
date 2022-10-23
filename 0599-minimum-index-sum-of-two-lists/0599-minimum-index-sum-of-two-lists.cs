public class Solution {
    public string[] FindRestaurant(string[] list1, string[] list2) {
        if (list1.Length > list2.Length)
            return FindRestaurant(list2, list1);

        var map = new Dictionary<string, int>();
        for (var i = 0; i < list1.Length; i++) {
            map.Add(list1[i], i);
        }
        var minSum = Int32.MaxValue;
        var ans = new List<string>();
        for (var i = 0; i < list2.Length; i++) {
            if (map.ContainsKey(list2[i])) { 
                var currSum = map[list2[i]] + i;
                if (currSum > minSum)
                    continue;
                if (currSum < minSum)
                {
                    ans.Clear();
                    minSum = currSum;
                }
                ans.Add(list2[i]);
            }
        }
        return ans.ToArray();
    }
}