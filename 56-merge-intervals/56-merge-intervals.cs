public class Solution {
    public int[][] Merge(int[][] intervals) {
         var intervalsList = intervals.OrderBy(x => x[0]).ToList();
            var resList = new List<int[]>();
            var intervStart = intervalsList[0];
            for (var i = 1; i < intervalsList.Count; i++) {
                var curr = intervalsList[i];
                if (curr[0] <= intervStart[1])
                {
                    if (curr[1] > intervStart[1])
                        intervStart[1] = curr[1];
                }
                else { 
                    resList.Add(intervStart);
                    intervStart = curr;
                }
            }
            resList.Add(intervStart);
            return resList.ToArray();
        }
    }
