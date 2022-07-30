public class Solution {
    public int EvalRPN(string[] tokens) {
    var operators = new HashSet<string>() { "+", "-", "*", "/"};
        var stack = new Stack<int>();
        var i = 0;
        while (i < tokens.Length) {
            if (operators.Contains(tokens[i]))
            {
                if (i > 0)
                {
                    var secondOperand = stack.Pop();
                    var firstOperand = stack.Pop();
                    stack.Push(GetResult(firstOperand, secondOperand, tokens[i]));
                }
            }
            else {
                stack.Push(Int32.Parse(tokens[i]));
            }
            i++;
        }
        return stack.Pop();
    }

    private int GetResult(int firstOperand, int secondOperand, string op)
    {
        switch (op) { 
            case "+":
                return firstOperand + secondOperand;
            case "-":
                return firstOperand - secondOperand;
            case "*":
                return firstOperand * secondOperand;
            case "/":
                return firstOperand / secondOperand;
            default:
                return 0;
        }
    }
}