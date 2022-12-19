public class Solution {
    public int MaximumPopulation(int[][] logs) {
        var birth = new int[logs.Length];
        var death = new int[logs.Length];
        for (var i = 0; i < logs.Length; i++) { 
            birth[i] = logs[i][0];
            death[i] = logs[i][1];
        }
        Array.Sort(birth);
        Array.Sort(death);
        var dId = 0;
        var max = 0;
        var curr = 0;
        var year = birth[0];
        for (var i = 0; i < birth.Length;) {
            if (birth[i] < death[dId])
            {
                curr++;
                if (curr > max)
                {
                    year = birth[i];
                    max = curr;
                }
                i++;
            }
            else {
                curr--;
                dId++;
            }
        }
        return year;
    }
}