public class Solution {
    public int Calculate(string s) {
        var stack = new Stack<int>();
        var currentNumber = 0;
        var currOperator = '+';
        for (var sId = 0; sId < s.Length; sId++) {
            if (char.IsDigit(s[sId]))
            {
                currentNumber = currentNumber * 10 + (s[sId] - '0');
                if(sId < s.Length - 1)
                    continue;
            }
            if (s[sId] == ' ' && sId < s.Length - 1)
                continue;
                
            switch (currOperator) { 
                case '-':
                        currentNumber = -currentNumber;
                        break;
                case '*':
                    if (stack.Count > 0)
                    {
                        currentNumber *= stack.Pop();
                    }
                    break;
                case '/':
                    if (stack.Count > 0) {
                        currentNumber = stack.Pop() / currentNumber;
                    }
                    break;
                default:
                    break;
            }
            stack.Push(currentNumber);
            currentNumber = 0;
            currOperator = s[sId];
        }
        var sum = 0;
        while (stack.Count > 0) {
            sum += stack.Pop();
        }
        return sum;
    }
}