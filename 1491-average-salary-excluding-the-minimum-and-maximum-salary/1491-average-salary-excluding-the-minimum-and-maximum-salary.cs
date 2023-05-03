public class Solution {
    public double Average(int[] salary) {
        int min = salary[0];
        int max = salary[0];
        double sum = 0;
        foreach (int s in salary) {
            sum += s;
            if(s < min)
                min = s;
            if(s > max)
                max = s;
        }
        return (sum - min - max) / (salary.Length - 2);
    }
}