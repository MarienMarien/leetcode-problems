public class Solution {
    public int FinalPositionOfSnake(int n, IList<string> commands) {
        var commandsCoefs = new Dictionary<string, int> {
            { "RIGHT", 1 },
            { "DOWN", n },
            { "LEFT", -1 },
            { "UP", -n }
        };

        var cell = 0;
        foreach (var c in commands)
        {
            cell += commandsCoefs[c];
        }

        return cell;
    }
}