public class Solution {
    public bool RotateString(string s, string goal) {
        var found = false;
        if (s.Length != goal.Length)
            return found;
        var rotationId = 0;
        while (!found && rotationId < goal.Length) {
            found = true;
            for (var i = 0; i < s.Length; i++) {
                var goalId = (rotationId + i) % goal.Length;
                if (s[i] != goal[goalId]) {
                    found = false;
                    rotationId++;
                    break;
                }
            }

        }

        return found;
    }
}