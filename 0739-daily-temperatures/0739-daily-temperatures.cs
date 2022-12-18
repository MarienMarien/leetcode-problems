public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var res = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (var i = 0; i < temperatures.Length; i++) {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var prevDay = stack.Pop();
                res[prevDay] = i - prevDay;
            }
            stack.Push(i);
        }
        return res;
    }
}