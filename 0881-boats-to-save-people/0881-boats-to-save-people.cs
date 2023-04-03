public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        var count = 0;
        Array.Sort(people);
        var start = 0;
        var end = people.Length - 1;
        while (start <= end) {
            if (people[start] + people[end] > limit)
            {
                end--;
            }
            else {
                start++;
                end--;
            }
            count++;
        }
        return count;
    }
}