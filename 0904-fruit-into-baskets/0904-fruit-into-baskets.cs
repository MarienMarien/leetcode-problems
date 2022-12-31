public class Solution {
    public int TotalFruit(int[] fruits) {
        Console.WriteLine($"TestStart");
        var fruit1 = -1;
        var fruit2 = -1;
        var nextStart = -1;
        var start = 0;
        var end = 0;
        var max = 0;
        while (end < fruits.Length) {
            if(fruit1 != -1 && fruit2 != -1 && fruits[end] != fruit1 && fruits[end] != fruit2){
                max = Math.Max(max, end - start);
                start = nextStart;
                fruit1 = fruits[nextStart];
                fruit2 = fruits[end];
                nextStart = end;
            }
            if(fruit1 == -1){
                fruit1 = fruits[end];
            }
            else if(fruit2 == -1 && fruits[end] != fruit1){
                fruit2 = fruits[end];
            }
            if(nextStart == -1 || fruits[end] != fruits[nextStart])
                nextStart = end;
            end++;
       }
       max = Math.Max(max, end - start);
       return max;
    }
}